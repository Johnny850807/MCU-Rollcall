using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MCR.models;
using MCR.models.viewmodels;
using System.Drawing;
using System.IO;
using MCR.views.presenters;

namespace MCR.views
{
    public partial class RollcallUserDefinedSessionPanel : BaseRollcallConsolePanel , RollcallUserDefinedSessionView
    {
        private RollcallSession rollcallSession;
        private McrFactory mcrFactory;
        private RollcallView rollcallView;
        private RollcallUserDefinedSessionPresenter rollcallUserDefinedSessionPresenter;

        private RollcallUserDefinedSessionPanel()
        {
            InitializeComponent();
        }

        public RollcallUserDefinedSessionPanel(McrFactory mcrFactory) : this()
        {
            this.mcrFactory = mcrFactory;
            this.rollcallUserDefinedSessionPresenter = new RollcallUserDefinedSessionPresenter(mcrFactory.createMcrRepository());
            this.rollcallUserDefinedSessionPresenter.setRollcallUserDefinedSessionView(this);
            this.studentsTablePanel.onStudentCellClicked = this.StudentCell_Clicked;
        }

        public void setRollcallView(RollcallView rollcallView)
        {
            this.rollcallView = rollcallView;
        }

        public override void onSessionCreated(Session session)
        {
            this.rollcallSession = RollcallSession.create(session);
            //courseId.Text = rollcallSession.subjectNumber;
            courseName.Text = rollcallSession.name + " / " + rollcallSession.subjectNumber;
            refreshCountLabel(rollcallSession);
            studentsTablePanel.loadSessionStudents(rollcallSession);
            rollcallView.stopServerAndResetStates();
        }

        public override Session getCurrentSession()
        {
            if (rollcallSession == null)
                return null;
            return rollcallSession.toSession();
        }

        public override void signAllStudents(bool signed)
        {
            rollcallSession.signAllStudents(signed);
            studentsTablePanel.loadSessionStudents(rollcallSession);
        }

        public override bool isRollcallSessionStarted()
        {
            return rollcallSession != null;
        }

        public override bool isStudentValid(Student student)
        {
            // all students should be valid if his data is valid, 
            // so he can be added into the session.
            return student.isValid();
        }

        public override bool containsStudent(Student student)
        {
            return rollcallSession.containsStudent(student);
        }

        public override List<Student> getCurrentStudents()
        {
            return rollcallSession.getCurrentStudents();
        }

        public override List<Student> getSignedStudents()
        {
            return rollcallSession.getSignedStudents();
        }

        public override List<Student> getUnsignedStudents()
        {
            return rollcallSession.getUnsignedStudents();
        }

        public override bool isSigned(Student student)
        {
            return rollcallSession.isSigned(student);
        }
        
        public override void signStudent(Student student, bool signed)
        {
            rollcallSession.signStudent(student, signed);
            studentsTablePanel.addStudent(student, signed ? 
                RollcallStudent.State.SIGNED : RollcallStudent.State.UNSIGNED );
            refreshCountLabel(rollcallSession);
        }

        public override RollcallStudent.State getStudentState(Student student)
        {
            if (rollcallSession == null)
                return RollcallStudent.State.NONE;
            return rollcallSession.getStudentState(student);
        }

        public override void onStudentRemoved(Student student)
        {
            rollcallSession.removeStudent(student);
            studentsTablePanel.removeStudent(student);
            refreshCountLabel(rollcallSession);
        }

        public override void onStudentBlocked(Student student)
        {
            studentsTablePanel.addStudent(student, RollcallStudent.State.BLOCKED);
        }

        public override void createStudent(Student student)
        {
            rollcallUserDefinedSessionPresenter.createStudent(student);
        }

        public override void onRecordExport()
        {
            if (rollcallSession == null)
                MessageBox.Show("請先載入課程");
            else
            {
                var record = produceStudentSignRecord();
                using (var exportingDialog = new ExportingSignRecordDialog(record))
                {
                    exportingDialog.ShowDialog();
                }
            }
        }

        public void StudentCell_Clicked(StudentCell studentCell, MouseEventArgs e)
        {
            showContextMenuBesideMousePoint(studentCell);
        }

        private void showContextMenuBesideMousePoint(StudentCell studentCell)
        {
            var student = studentCell.student;
            var contextMenuHeader = new ContextMenuStrip();
            contextMenuHeader.Font = new Font("微軟正黑體", 15, FontStyle.Bold);
            contextMenuHeader.Items.Add("設置為出席");
            contextMenuHeader.Items.Add("設置為缺席");
            contextMenuHeader.Items.Add("設置請假理由");
            contextMenuHeader.Items.Add("唱名");
            contextMenuHeader.Items.Add("刪除學生");
            contextMenuHeader.Items.Add("封鎖學生");
            contextMenuHeader.Items[0].Click += (s,e) => this.signStudent(student, true);
            contextMenuHeader.Items[1].Click += (s,e) => this.signStudent(student, false);
            contextMenuHeader.Items[2].Click += (s, e) => this.createAndShowDialogForAddingStudentBeingAbsentReason(studentCell);
            contextMenuHeader.Items[3].Click += (s, e) => speakStudentName(student);
            contextMenuHeader.Items[4].Click += (s, e) => rollcallUserDefinedSessionPresenter.removeStudent(student);
            //contextMenuHeader.Items[5].Click += (s, e) => rollcallUserDefinedSessionPresenter.blockStudent(student);
            
            if (studentCell.state == RollcallStudent.State.SIGNED)
                contextMenuHeader.Items[2].Enabled = false;
            contextMenuHeader.Show(Cursor.Position);
        }
        public void speakStudentName(Student student)
        {
            var tts = mcrFactory.createTTS();
            tts.speak(student.name);
        }

        private void createAndShowDialogForAddingStudentBeingAbsentReason(StudentCell studentCell)
        {
            
            using (var setReasonDialog = new SetStudentBeingAbsentReasonDialog())
            {
                if (setReasonDialog.ShowDialog() == DialogResult.OK)
                {
                    var reason = setReasonDialog.reason;
                    if (studentCell.state == RollcallStudent.State.SIGNED)
                        MessageBox.Show("該學生已經簽到！(出席者還會有請假理由？)");
                    else if (!string.IsNullOrEmpty(reason))
                        studentCell.absentReasonText = reason;
                }
            }
        }
        
        private StudentRollcallRecord produceStudentSignRecord()
        {

            var record = new StudentRollcallRecord();
            record.session = rollcallSession.toSession();
            record.rollcallStudents = studentsTablePanel.getRollcallStudents();
            record.datetime = DateTime.Now;
            record.title = "";
            return record;
        }

        public void onUserSessionStudentCreatedSuccessfully(Student student)
        {
            this.signStudent(student, false);
            studentsTablePanel.alterRowAndColumnCount();
        }

        public void onError(Exception err)
        {
            throw new NotImplementedException();
        }

        private void refreshCountLabel(RollcallSession rollcallSession)
        {
            CountSignInStudentsLabel.Text = rollcallSession.getSignedStudents().Count.ToString() + " / " + rollcallSession.getRollcallStudents().Count.ToString() + " 人數";
        }

        private void userDefinedSessionParentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
       
    }
}
