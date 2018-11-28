using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCR.utils;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace MCR.models
{
    /// <summary>
    /// A 'class', a 'meeting' or any collective situation.
    /// </summary>
    public class Session
    {
        public string id { get; set; }
        public string ip { get; set; }  // which Ip the session taken under
        public string name { get; set; }
        public string subjectNumber { get; set; }
        public SessionType sessionType { get; set; } = SessionType.NONE;

        [JsonIgnore]
        public HashSet<Student> students { get; set; } = new HashSet<Student>();

        /// <summary>
        /// The type of the session, it might an user-defined session which is not binded to the school,
        /// or might be a school course, and so on.
        /// </summary>
        public enum SessionType
        {
            /// <summary>
            /// user's own defined classes
            /// </summary>
            USER_DEFINED,

            /// <summary>
            /// the school's course
            /// </summary>
            COURSE,

            /// <summary>
            /// none, used for detecting no type error
            /// </summary>
            NONE
        }
 
        
        
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Id: {0}, Ip: {1}, Name: {2}, Subject number: {3}", id, ip, name, subjectNumber);
        }

        public override bool Equals(object obj)
        {
            var session = obj as Session;
            return session != null &&
                   id == session.id &&
                   ip == session.ip &&
                   name == session.name &&
                   subjectNumber == session.subjectNumber &&
                   sessionType == session.sessionType;
        }
    }
}
