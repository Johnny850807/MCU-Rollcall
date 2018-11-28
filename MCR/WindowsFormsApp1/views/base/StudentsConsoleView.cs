using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    public interface StudentsConsoleView : MainThreadView, StudentInstancesListener
    {
        void onGetAllStudents(List<Student> students);
        void onGetUserSessionsSuccessfully(List<Session> session);
        void onGetUserSessionsUnsuccessfully(Exception err);
        void onError(Exception err);
    }
}
