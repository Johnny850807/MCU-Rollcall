using MCR.models;
using MCR.models.viewmodels;
using MCR.views;
using System.Collections.Generic;

namespace MCR.adapters
{
    /// <summary>
    /// Adapter interface we expect to act as a web browser, the main functions
    /// involve to keep last states of session and students.
    /// </summary>
    public interface RollcallWebBrowserAdapter : SessionStatesQuerier, StudentStatesQuerier, StudentStatesManipulator
    {
        List<RollcallStudent> getRollcallStudents();
        void setupRollcallPage(bool showPictures);
        void setShowingAllStudentPictures(bool show);
        void loadAccountAndPassword();
        bool isUnderRollcallPage();
        string getTeacherHomePageLink();
        bool isUnderLoginPage();
    }
}
