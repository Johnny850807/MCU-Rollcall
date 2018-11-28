using MCR.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCR.models;
using MCR.models.viewmodels;

namespace MCR
{
    public partial class SessionManagementDialog : BaseForm , SessionManagementView
    {
        public Session chosenSession { get; set; }
        public List<Session> sessions { get; set; }
        private SessionManagementPresenter sessionManagementPressenter;
        private McrFactory mcrFactory;
        private RollcallView rollcallView;

        public SessionManagementDialog(McrFactory mcrFactory)
        {
            InitializeComponent();
            this.mcrFactory = mcrFactory;
            this.sessionManagementPressenter = new SessionManagementPresenter(mcrFactory.createMcrRepository());
            sessionManagementPressenter.setSessionManagementView(this);
        }

        public void SessionManagementDialog_Load(object senver, EventArgs e)
        {
            sessionManagementPressenter.onGetUserSessions();
        }

        private void loadSelectCourseButton_Click(object sender, EventArgs e)
        {
            if (sessionManagementDialogListView.SelectedItems.Count > 0)
                this.chosenSession = sessions[sessionManagementDialogListView.SelectedIndices[0]];
        }
        
        private void createCourseButton_Click(object sender, EventArgs e)
        {
            using (CreateSessionDialog createSessionDialog = new CreateSessionDialog())
            {
                if (createSessionDialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(createSessionDialog.courseNameText))
                        MessageBox.Show("課程名稱要填");
                    else
                    {
                        var session = createSessionFromInput(createSessionDialog);
                        sessionManagementPressenter.createSession(session);
                        // TODO: UX needed make sure if the session actually stored successfully.
                        ListViewItem item = new ListViewItem(createSessionDialog.courseNameText);
                        item.SubItems.Add(createSessionDialog.courseIdText);
                        sessionManagementDialogListView.Items.Add(item);
                    }
                }
            }
        }

        public Session createSessionFromInput(CreateSessionDialog createSessionDialog)
        {
            return new Session()
            {
                name = createSessionDialog.courseNameText,
                subjectNumber = createSessionDialog.courseIdText,
                sessionType = Session.SessionType.USER_DEFINED
            };
        }
        
        public void onUserSessionCreatedSuccessfully(Session session)
        {
            this.sessions.Add(session);
        }

        public void onError(Exception err)
        {
            MessageBox.Show("發生問題: " + err.Message + "[" + err.StackTrace + "] 請通知開發人員。");
        }

        public void onSessionCreated(Session session)
        {
            sessionManagementPressenter.createSession(session);
        }

        public void onRemoveSession(Session session)
        {
            sessionManagementPressenter.removeUserSelectedSession(session);
        }
        public void onUserSessionsGetSuccessfully(List<Session> sessions)
        {
            this.sessions = sessions;
            foreach (Session s in sessions)
            {
                ListViewItem item = new ListViewItem(s.name);
                item.SubItems.Add(s.subjectNumber);
                sessionManagementDialogListView.Items.Add(item);
            }
        }

        public void onRemoveUserSelectedSessionSuccessfully(Session session)
        {
            MessageBox.Show("Deleted session successfully : " + session.name);
        }

        private void deleteSessionButton_Click(object sender, EventArgs e)
        {
            if (sessionManagementDialogListView.SelectedItems.Count > 0)
            {
                this.chosenSession = sessions[sessionManagementDialogListView.SelectedIndices[0]];
                sessions.Remove(this.chosenSession);
                onRemoveSession(this.chosenSession);
                sessionManagementDialogListView.Items.RemoveAt(sessionManagementDialogListView.SelectedIndices[0]);
            }
                
            
            
        }

        private void editSessionButton_Click(object sender, EventArgs e)
        {
            if (sessionManagementDialogListView.SelectedItems.Count > 0)
            {
                this.chosenSession = sessions[sessionManagementDialogListView.SelectedIndices[0]];
                
                using (EditSessionDialog editSessionDialog = new EditSessionDialog())
                {
                    if (editSessionDialog.ShowDialog() == DialogResult.OK)
                    {

                        this.chosenSession.name = editSessionDialog.session.name;
                        if (editSessionDialog.session.subjectNumber.Length > 0)
                            this.chosenSession.subjectNumber = editSessionDialog.session.subjectNumber;
                        
                        sessionManagementPressenter.editUserSelectedSession(this.chosenSession);
                        sessionManagementDialogListView.SelectedItems[0].SubItems[0].Text = chosenSession.name;
                        sessionManagementDialogListView.SelectedItems[0].SubItems[1].Text = chosenSession.subjectNumber;

                    }
                }
            }
        }

        public void onUserSessionModifySuccessfully(Session session)
        {
            MessageBox.Show(session.name + " : User session modify successfully");
        }
    }
}
