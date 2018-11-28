using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR
{
    public interface StudentInstancesListener
    {
        void onStudentRemoved(Student student);
        void onStudentBlocked(Student student);
    }
}
