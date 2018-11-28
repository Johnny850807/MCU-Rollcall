using MCR.models;
using MCR.models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views.presenters
{
    public class StudentsConsolePresenter
    {
        private McrRepository mcrRepository;
        private StudentsConsoleView studentsConsoleView;

        public StudentsConsolePresenter(McrRepository mcrRepository)
        {
            this.mcrRepository = mcrRepository;
        }

        public void setStudentsConsoleView(StudentsConsoleView studentsConsoleView)
        {
            this.studentsConsoleView = studentsConsoleView;
        }

        public void loadAllUserSessions()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var sessions = mcrRepository.getSessions();
                    studentsConsoleView.invokeOnMainThread(() => 
                        studentsConsoleView.onGetUserSessionsSuccessfully(sessions));
                }
                catch (Exception err) {
                    studentsConsoleView.invokeOnMainThread(() =>
                        studentsConsoleView.onGetUserSessionsUnsuccessfully(err));
                }
            });
        }

        public void loadAllStudents()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var students = mcrRepository.getStudents();
                    studentsConsoleView.invokeOnMainThread(() =>
                        studentsConsoleView.onGetAllStudents(students));
                }
                catch (Exception err)
                {
                    studentsConsoleView.invokeOnMainThread(() =>
                        studentsConsoleView.onError(err));
                }
            });
        }

        public void removeStudent(Student student)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    student = mcrRepository.removeStudent(student.id);
                    studentsConsoleView.invokeOnMainThread(() =>
                        studentsConsoleView.onStudentRemoved(student));
                }
                catch (Exception err)
                {
                    studentsConsoleView.invokeOnMainThread(() =>
                        studentsConsoleView.onError(err));
                }
            });
        }

        public void blockStudent(Student student)
        {
            Task.Factory.StartNew(() =>
            {
                //TODO
            });
        }
    }
}
