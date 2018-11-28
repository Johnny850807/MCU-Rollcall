using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    public interface RollcallUserDefinedSessionView : MainThreadView
    {
        void onStudentRemoved(Student student);
        void onUserSessionStudentCreatedSuccessfully(Student student);
        void onError(Exception err);
    }
}
    
