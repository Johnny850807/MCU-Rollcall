using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.viewmodels
{
    public class RollcallStudent
    {
        private Student _student;
        public string id { get { return _student.id; } set { _student.id = value; } }
        public string ip { get { return _student.ip; } set { _student.ip = value; } }
        public string name { get { return _student.name; } set { _student.name = value; } }
        public string studentId { get { return _student.studentId; } set { _student.studentId = value; } }
        public string absentReason { get; set; }
        public State state { get; set; }

        public enum State
        {
            SIGNED, UNSIGNED, NONE, BLOCKED
        }

        public string stateToString() {
            switch(state)
            {
                case State.SIGNED:
                    return "出席";
                case State.BLOCKED:
                    return "封鎖";
                case State.NONE:
                    return "無";
                case State.UNSIGNED:
                    string msg = "缺席";
                    if (!string.IsNullOrEmpty(absentReason))
                        msg += ": " + absentReason;
                    return msg;
            }
            throw new Exception("State " + state + " no matched.");
        }

        public static RollcallStudent create(Student student, bool signed)
        {
            return new RollcallStudent(student, signed ? State.SIGNED : State.UNSIGNED);
        }

        public static RollcallStudent create(Student student, State state)
        {
            return new RollcallStudent(student, state);
        }

        public RollcallStudent(Student student, State state)
        {
            this._student = student;
            this.state = state;
        }

        public RollcallStudent(string id, string ip, string name, string studentId, State state)
        {
            this._student = new Student(id, ip, name, studentId);
            this.state = state;
        }

        public bool isSigned()
        {
            return state == State.SIGNED;
        }

        public Student getStudent()
        {
            return _student;
        }
    }
}
