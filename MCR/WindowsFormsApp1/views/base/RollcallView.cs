using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    public interface RollcallView : MainThreadView, LoggerView
    {
        void onStudentSignIn(Student student);
        void onStudentBlocked(Student student);
        void onQRCodeCountDown(int time);
        void onQRCodeTokenUpdated(string token);
        void stopServerAndResetStates();
    }
}
