using MCR.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCR.models;

namespace UnitTests
{
    public class TestRollcallView : RollcallView
    {
        public Exception err { get; set; }
        public List<string> logs { get; set; } = new List<string>();
        public string qrcodeToken { get; set; }
        public List<Student> signedInStudent { get; set; }
        public List<Session> userSessions { get; set; }
        public List<Participation> addedParticipations { get; set; }
        public List<Participation> removedParticipations { get; set; }
        public List<Student> blockedStudents { get; set; }
        public List<Student> removedStudents { get; set; }
        public List<Session> createdSessions { get; set; }
        public List<Session> removedSessions { get; set; }


        public void addLogToTextbox(string msg, bool newLine = true)
        {
            this.logs.Add(msg + (newLine ? Environment.NewLine : ""));
        }

        public void addNewLog(string log, bool newLine = true)
        {
            throw new NotImplementedException();
        }

        public void invokeOnMainThread(System.Windows.Forms.MethodInvoker methodInvoker)
        {
            Task.Factory.StartNew(() => methodInvoker.Invoke());
        }

        public T invokeOnMainThread<T>(Func<T> methodInvoker)
        {
            return Task<T>.Factory.StartNew(() => methodInvoker.Invoke()).Result;        
        }

        public void onError(Exception err)
        {
            this.err = err;
        }

        public void onGetUserSessions(List<Session> sessions)
        {
            this.userSessions = sessions;
        }

        public void onParticipationAddedSuccessfully(Participation participation)
        {
            this.addedParticipations.Add(participation);
        }

        public void onParticipationRemovedSuccessfully(Participation participation)
        {
            this.removedParticipations.Add(participation);
        }

        public void onQRCodeCountDown(int time)
        {
            throw new NotImplementedException();
        }

        public void onQRCodeTokenUpdated(string token)
        {
            throw new NotImplementedException();
        }

        public void onQRCodeUpdated(string address, string newToken)
        {
            this.qrcodeToken = newToken;
        }

        public void onStudentBlocked(Student student)
        {
            this.blockedStudents.Add(student);
        }

        public void onStudentRemovedSuccessfully(Student student)
        {
            this.removedStudents.Add(student);
        }

        public void onStudentSignIn(Student student)
        {
            this.signedInStudent.Add(student);
        }

        public void stopServerAndResetStates()
        {
            throw new NotImplementedException();
        }
    }
}
