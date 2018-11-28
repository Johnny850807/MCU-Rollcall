using MCR.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.viewmodels
{
    /// <summary>
    /// The session view model storing the rollcall state of each student additionally.
    /// </summary>
    public class RollcallSession : StudentStatesQuerier, StudentStatesManipulator
    {
        private Session _session;
        public string id { get { return _session.id; } set { _session.id = value; } }
        public string ip { get { return _session.ip; } set { _session.ip = value; } }
        public string name { get { return _session.name; } set { _session.name = value; } }
        public string subjectNumber { get { return _session.subjectNumber; } set { _session.subjectNumber = value; } }
        public Session.SessionType sessionType { get { return _session.sessionType; } set { _session.sessionType = value; } }
        public Dictionary<Student, bool> signStateTable { get; set; }


        public static RollcallSession create(Session session)
        {
            var sm = new RollcallSession(session);
            sm.signStateTable = new Dictionary<Student, bool>();
            foreach (var student in session.students)
                sm.signStateTable[student] = false;
            return sm;
        }

        private RollcallSession(Session session)
        {
            this._session = session;
        }

        public List<RollcallStudent> getRollcallStudents()
        {
            return signStateTable.Select(s =>
                RollcallStudent.create(s.Key, s.Value)).ToList();
        }

        public List<Student> getCurrentStudents()
        {
            return signStateTable.Keys.ToList();
        }

        public List<Student> getSignedStudents()
        {
            return signStateTable.Keys.Where(s => signStateTable[s]).ToList();
        }

        public List<Student> getUnsignedStudents()
        {
            return signStateTable.Keys.Where(s => !signStateTable[s]).ToList();
        }
        
        public RollcallStudent.State getStudentState(Student student)
        {
            if (!signStateTable.ContainsKey(student))
                return RollcallStudent.State.NONE;
            if (isSigned(student))
                return RollcallStudent.State.SIGNED;
            return RollcallStudent.State.UNSIGNED;
        }

        public void signAllStudents(bool signed)
        {
            foreach (var student in getCurrentStudents())
                this.signStateTable[student] = signed;
        }

        public bool isSigned(Student student)
        {
            return signStateTable[student];
        }

        public List<RollcallStudent> getStudentSignStates()
        {
            return signStateTable.Select(s => RollcallStudent.create(s.Key, s.Value)).ToList();
        }
        
        public void signStudent(Student student, bool signed)
        {
            this.signStateTable[student] = signed;
        }

        public void removeStudent(Student student)
        {
            this.signStateTable.Remove(student);
            _session.students.Remove(student);
        }

        public Session toSession()
        {
            return _session;
        }

        public bool containsStudent(Student student)
        {
            return this._session.students.Contains(student);
        }

        public bool isStudentValid(Student student)
        {
            return student.isValid();
        }
    }
}
