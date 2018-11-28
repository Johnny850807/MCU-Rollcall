using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.viewmodels
{
    public interface StudentStatesManipulator
    {
        void signStudent(Student student, bool signed);
        void signAllStudents(bool signed);
    }
}
