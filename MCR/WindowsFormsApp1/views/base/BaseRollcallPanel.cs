using System.Collections.Generic;
using MCR.models;
using MCR.models.viewmodels;
using System.Windows.Forms;
using MCR.views.presenters;

namespace MCR.views
{
    public class BaseRollcallConsolePanel : BaseUserControl, 
                                            SessionStatesQuerier,
                                            StudentStatesQuerier,
                                            StudentStatesManipulator,
                                            StudentInstancesListener
    {
        public delegate void RollcallSessionPrepared();
        public event RollcallSessionPrepared rollcallSessionPrepared;
        public delegate void LeavingRollcallPage();
        public event LeavingRollcallPage leavingRollcallPage;

        public void invokeRollcallSessionPreparedEvent() {
            rollcallSessionPrepared?.Invoke();
        }
        public void invokeLeavingRollcallPageEvent() {
            leavingRollcallPage?.Invoke();
        }

        public virtual bool isRollcallSessionStarted()
        {
            throw new System.NotImplementedException();
        }

        public virtual Session getCurrentSession()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool isSigned(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool containsStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool isStudentValid(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual RollcallStudent.State getStudentState(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<Student> getCurrentStudents()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<Student> getSignedStudents()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<Student> getUnsignedStudents()
        {
            throw new System.NotImplementedException();
        }

        public virtual void signStudent(Student student, bool signed)
        {
            throw new System.NotImplementedException();
        }

        public virtual void signAllStudents(bool signed)
        {
            throw new System.NotImplementedException();
        }

        public virtual void onStudentRemoved(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual void onStudentBlocked(Student student)
        {
            throw new System.NotImplementedException();
        }
        
        public virtual void createStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public virtual void onSessionCreated(Session session)
        {
            throw new System.NotImplementedException();
        }

        public virtual void onRecordExport()
        {
            throw new System.NotImplementedException();
        }
    }
}
