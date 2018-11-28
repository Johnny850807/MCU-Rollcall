using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.viewmodels
{
    public class StudentRollcallRecord
    {
        public DateTime datetime { get; set; }
        public string title { get; set; }
        public Session session { get; set; }
        public List<RollcallStudent> rollcallStudents { get; set; }
    }
}
