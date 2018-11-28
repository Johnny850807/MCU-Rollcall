using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models
{
    public class Participation
    {
        public string sessionId { get; set; }
        public string studentId { get; set; }

        public Participation(){}

        public Participation(string sessionId, string studentId)
        {
            this.sessionId = sessionId;
            this.studentId = studentId;
        }

        public override bool Equals(object obj)
        {
            var participation = obj as Participation;
            return participation != null &&
                   sessionId == participation.sessionId &&
                   studentId == participation.studentId;
        }

        public override int GetHashCode()
        {
            var hashCode = -1800327833;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(sessionId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(studentId);
            return hashCode;
        }
    }
}
