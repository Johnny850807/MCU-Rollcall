using MCR.models;
using MCR.models.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR
{
    public interface StudentStatesQuerier
    {
        bool isSigned(Student student);
        bool containsStudent(Student student);
        bool isStudentValid(Student student);
        RollcallStudent.State getStudentState(Student student);
        List<Student> getCurrentStudents();
        List<Student> getSignedStudents();
        List<Student> getUnsignedStudents();
    }
}
