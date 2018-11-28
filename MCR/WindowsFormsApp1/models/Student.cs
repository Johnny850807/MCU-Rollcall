using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models
{
    public class Student
    {
        public string id { get; set; }
        public string ip { get; set; }
        public string name { get; set; }
        public string studentId { get; set; }
        public DateTime expires { get; set; }

        public Student() { }

        public Student(string id, string ip, string name, string studentId)
        {
            this.id = id;
            this.ip = ip;
            this.name = name;
            this.studentId = studentId;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   ip == student.ip &&
                   name == student.name &&
                   studentId == student.studentId;
        }
        
        public override int GetHashCode()
        {
            var hashCode = 148588527;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ip);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(studentId);
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format("Id: {0}, Ip: {1}, StudentId: {2}, Name: {3}", 
                id, ip, studentId, name);
        }

        public bool expired()
        {
            return expires < DateTime.Now;
        }

        public bool isValid()
        {
            return id != null && ip != null && name != null && studentId != null;
        }
    }
}
