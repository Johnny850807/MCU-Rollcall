using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCR.views.presenters;
using MCR.models;
using MCR.utils;
using MCR.models.viewmodels;
using static MCR.models.Session;

namespace MCR.views
{
    public partial class StudentsConsolePanel : BaseUserControl, StudentsConsoleView
    {
        private const string TAG = "StudentsConsolePanel";
        private const int CURRENT_SESSION = 0;
        private const int ALL_STUDENTS = 1;

        private McrFactory mcrFactory;
        private List<StudentInstancesListener> studentInstancesListeners = new List<StudentInstancesListener>();
        private SessionStatesQuerier sessionStatesQuerier;
        private StudentStatesQuerier studentStatesQuerier;
        private LoggerView loggerView;
        private StudentsConsolePresenter presenter;
        private List<Session> userSessions = new List<Session>();
        private int currentIndex;

        private StudentsConsolePanel()
        {
            InitializeComponent();
        }

        public StudentsConsolePanel(McrFactory mcrFactory, 
                                SessionStatesQuerier sessionStatesQuerier,
                                StudentStatesQuerier studentsQuerier,
                                LoggerView loggerView) : this()
        {
            this.mcrFactory = mcrFactory;
            this.sessionStatesQuerier = sessionStatesQuerier;
            this.studentStatesQuerier = studentsQuerier;
            this.loggerView = loggerView;
            this.studentsInfoTableLayoutPanel.onStudentCellClicked = this.StudentCell_Clicked;
            
            presenter = new StudentsConsolePresenter(mcrFactory.createMcrRepository());
            presenter.setStudentsConsoleView(this);
        }

        public void addStudentInstanceListener(StudentInstancesListener studentInstancesListener)
        {
            this.studentInstancesListeners.Add(studentInstancesListener);
        }

        public void removeStudentInstanceListener(StudentInstancesListener studentInstancesListener)
        {
            this.studentInstancesListeners.Remove(studentInstancesListener);
        }

        public void StudentsConsolePanel_Load(object sender, EventArgs e)
        {
            reloadAllStatesAndUpdate();
            currentIndex = sessionsComboBox.SelectedIndex;
        }

        /// <summary>
        /// Invoke this method would cause reloading all sessions into the ComboBox,
        /// therefore so its index changed with redrawing the student states if changed.
        /// </summary>
        public void reloadAllStatesAndUpdate()
        {
            presenter.loadAllUserSessions();
        }

        public void onGetUserSessionsSuccessfully(List<Session> session)
        {
            this.userSessions = session;
            loadSessionsIntoComboBox(userSessions);
        }

        public void onGetUserSessionsUnsuccessfully(Exception err)
        {
            Log.err(TAG, "onGetUserSessionsUnsuccessfully", err);
            ViewUtils.showError("無法取得使用者所有課程！請再嘗試一次。");
        }

        private void loadSessionsIntoComboBox(List<Session> sessions)
        { 
            sessionsComboBox.Items.Clear();
            sessionsComboBox.Items.Add("當課課程");
            sessionsComboBox.Items.Add("全部學生");
            foreach (var session in sessions)
                sessionsComboBox.Items.Add(session.name + "/" + session.subjectNumber);

            // automatically select 'current session' students while the rollcall is started.
            sessionsComboBox.SelectedIndex = sessionStatesQuerier.isRollcallSessionStarted() ?
                CURRENT_SESSION : ALL_STUDENTS;
        }

        public void updateStudentState(Student student, RollcallStudent.State state)
        {
            studentsInfoTableLayoutPanel.addStudent(student, state);
        }

        private void studentsInfoSessionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the index actually changed, clear the student cells.
            if (currentIndex != sessionsComboBox.SelectedIndex)
            {
                studentsInfoTableLayoutPanel.clearStudents();
                currentIndex = sessionsComboBox.SelectedIndex;
            }

            // reload all students so that we can see which students we have
            // with the latest updated database.
            presenter.loadAllStudents();
        }

        public void onGetAllStudents(List<Student> students)
        {
            // while we get the latest updated all students, update the states
            addOrUpdateStudentStates(students);
        }

        public void addOrUpdateStudentStates(List<Student> allStudents)
        {
            var comboBoxInx = sessionsComboBox.SelectedIndex;
            if (comboBoxInx == ALL_STUDENTS)
                addOrUpdateStudents(allStudents, studentStatesQuerier);
            else if (comboBoxInx == CURRENT_SESSION)
                addOrUpdateCurrentStudents(allStudents);
            else
            {   // The first index is 'All Students', the second is 'Current Session'
                // So index - 2 would be the relative index of the user sessions.
                var sessionIndex = comboBoxInx - 2;
                addOrUpdateSpecifiedSessionStudents(sessionIndex);
            }
        }

        private void addOrUpdateCurrentStudents(List<Student> allStudents)
        {
            //(allStudents) intersect (current session's students) = 
            //Students those in current session and also exist in database
            var ownStudentsInCurrentSession = 
                allStudents.Intersect(studentStatesQuerier.getCurrentStudents()).ToList();
            if (sessionStatesQuerier.isRollcallSessionStarted())
                addOrUpdateStudents(
                                ownStudentsInCurrentSession,
                                studentStatesQuerier);
            else
                studentsInfoTableLayoutPanel.clearStudents();
        }

        private void addOrUpdateSpecifiedSessionStudents(int sessionIndex)
        {
            if (sessionIndex >= 0)
            {
                var session = userSessions[sessionIndex];
                addOrUpdateStudents(session.students.ToList(), studentStatesQuerier);
            }
        }


        /// <summary>
        /// For enhancing the speed, this method does all computations in another thread.
        /// Update the student if (1) he's not in the table (2) he's state is changed.
        /// Should still be enhanced though.
        /// </summary>
        private void addOrUpdateStudents(List<Student> students, StudentStatesQuerier studentStatesQuerier)
        {
            var cellTable = studentsInfoTableLayoutPanel.cellTable;
            Task.Factory.StartNew(() =>
            {
                foreach (var student in students)
                {
                    var state = invokeOnMainThread(()=> studentStatesQuerier.getStudentState(student));
                    if (!cellTable.ContainsKey(student))
                        invokeOnMainThread(() => studentsInfoTableLayoutPanel.addStudent(student, state));
                    else if (cellTable[student].state != state)  // update only if the state changed.
                        invokeOnMainThread(() => cellTable[student].state = state);
                }
            });
        }

        public void StudentCell_Clicked(StudentCell studentCell, MouseEventArgs e)
        {
            showContextMenuBesideMousePoint(studentCell.student);
        }

        private void showContextMenuBesideMousePoint(Student student)
        {
            var contextMenuHeader = new ContextMenuStrip();
            contextMenuHeader.Font = new Font("微軟正黑體", 15, FontStyle.Bold);
            contextMenuHeader.Items.Add("唱名");
            contextMenuHeader.Items.Add("刪除學生");
            contextMenuHeader.Items.Add("封鎖學生");
            contextMenuHeader.Items[0].Click += (sender, e) => speakStudentName(student);
            contextMenuHeader.Items[1].Click += (sender, e) => presenter.removeStudent(student);
            contextMenuHeader.Items[2].Click += (sender, e) => presenter.blockStudent(student);
            contextMenuHeader.Show(Cursor.Position);
        }

        public void speakStudentName(Student student)
        {
            var tts = mcrFactory.createTTS();
            tts.speak(student.name);
        }

        public void onStudentRemoved(Student student)
        {
            loggerView.addNewLog("學生 [" + student.name + "] 已被刪除。");
            studentsInfoTableLayoutPanel.removeStudent(student);
            studentInstancesListeners.ForEach(l => l.onStudentRemoved(student));

        }

        public void onStudentBlocked(Student student)
        {
            loggerView.addNewLog("學生 [" + student.name + "] 已被封鎖。");
            studentsInfoTableLayoutPanel.addStudent(student, RollcallStudent.State.BLOCKED);
            var cell = studentsInfoTableLayoutPanel.cellTable[student];
            cell.Enabled = false;
        }
        
        public void onError(Exception err)
        {
            Log.err(TAG, "error occurs.", err);
            MessageBox.Show("發生錯誤！請再嘗試一次！");
        }
    }
}
