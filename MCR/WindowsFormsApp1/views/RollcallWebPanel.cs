using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCR.adapters;
using MCR.models;
using MCR.models.viewmodels;
using MCR.exceptions;
using MCR.utils;

namespace MCR.views
{
    public partial class RollcallWebPanel : BaseRollcallConsolePanel
    {
        private RollcallWebBrowserAdapter browserAdapter;
        private LoggerView loggerView;
        private bool isInRollcallPage = false;
        
        public Session currentSessionCache;

        public RollcallWebPanel(McrFactory mcrFactory)
        {
            InitializeComponent();
            this.browserAdapter = new MingChuanWebAdapter(webBrowser, mcrFactory.getNetStatesManager());
        }

        private void setLoggerView(LoggerView loggerView)
        {
            this.loggerView = loggerView;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (browserAdapter.isUnderLoginPage())
                browserAdapter.loadAccountAndPassword();
            else if (browserAdapter.isUnderRollcallPage())
                setupRollcallStates();
            else  //not in the rollcall page
                resetRollcallStates();
        }

        private void setupRollcallStates()
        {
            browserAdapter.setupRollcallPage(setShowingAllPictureChb.Checked);
            this.currentSessionCache = browserAdapter.getCurrentSession();
            this.isInRollcallPage = true;
            invokeRollcallSessionPreparedEvent();
        }

        private void resetRollcallStates()
        {
            if (isInRollcallPage)
                invokeLeavingRollcallPageEvent();
            isInRollcallPage = false;
            this.currentSessionCache = null;
        }

        private void setShowingAllPictureChb_CheckedChanged(object sender, EventArgs e)
        {
            if (isInRollcallPage)
                browserAdapter.setShowingAllStudentPictures(setShowingAllPictureChb.Checked);
        }

        public bool alertIfNotUnderRollcallPage(string msg = "請先至點名頁面，或載入自定義課程唷！")
        {
            if (!isInRollcallPage)
                MessageBox.Show(msg);
            return isInRollcallPage;
        }

        private void webbrowserPreviousPageBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void webbrowserNextPageBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void goHomeBtn_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(browserAdapter.getTeacherHomePageLink());
        }

        public override void signStudent(Student student, bool signed)
        {
            validateIsInRollcallPage();
            browserAdapter.signStudent(student, signed);
        }

        public override void signAllStudents(bool signed)
        {
            validateIsInRollcallPage();
            this.browserAdapter.signAllStudents(signed);
        }
        
        public override bool isRollcallSessionStarted()
        {
            return isInRollcallPage;
        }

        public override Session getCurrentSession()
        {
            validateIsInRollcallPage();
            return currentSessionCache;
        }

        public override bool isStudentValid(Student student)
        {
            // if the student is not in the students list from rollcall website
            // means he's not valid and not registered in the course.
            return student.isValid() && containsStudent(student);
        }

        public override bool containsStudent(Student student)
        {
            return currentSessionCache.students.Contains(student);
        }

        public override List<Student> getCurrentStudents()
        {
            return currentSessionCache.students.ToList();
        }

        public override List<Student> getUnsignedStudents()
        {
            return browserAdapter.getUnsignedStudents();
        }

        public override List<Student> getSignedStudents()
        {
            return browserAdapter.getSignedStudents();
        }

        public override bool isSigned(Student student)
        {
            return browserAdapter.isSigned(student);
        }

        public override RollcallStudent.State getStudentState(Student student)
        {
            return browserAdapter.getStudentState(student);
        }

        public void loadAccountAndPassword() {
            if (browserAdapter.isUnderLoginPage())
                browserAdapter.loadAccountAndPassword();
        }

        public void validateIsInRollcallPage()
        {
            if (!isInRollcallPage)
                throw new RollcallStateException("Not in the rollcall page!");
        }

        public override void onStudentRemoved(Student student){}

        public override void onStudentBlocked(Student student){}
    }
}
