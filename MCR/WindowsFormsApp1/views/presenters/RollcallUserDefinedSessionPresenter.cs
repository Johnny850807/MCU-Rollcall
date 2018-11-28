using MCR.models;
using MCR.models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views.presenters
{
    class RollcallUserDefinedSessionPresenter
    {
        private McrRepository mcrRepository;
        private RollcallUserDefinedSessionView rollcallUserDefinedSessionView;

        public RollcallUserDefinedSessionPresenter(McrRepository mcrRepository)
        {
            this.mcrRepository = mcrRepository;
        }

        public void setRollcallUserDefinedSessionView(RollcallUserDefinedSessionView rollcallUserDefinedSessionView)
        {
            this.rollcallUserDefinedSessionView = rollcallUserDefinedSessionView;
        }

        public void createStudent(Student student)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    mcrRepository.createStudent(student);
                    rollcallUserDefinedSessionView.invokeOnMainThread(() =>
                        rollcallUserDefinedSessionView.onUserSessionStudentCreatedSuccessfully(student));
                }
                catch (Exception err) { rollcallUserDefinedSessionView.invokeOnMainThread(() => rollcallUserDefinedSessionView.onError(err)); }
            });
        }
        public void removeStudent(Student student)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    student = mcrRepository.removeStudent(student.id);
                    rollcallUserDefinedSessionView.invokeOnMainThread(() =>
                        rollcallUserDefinedSessionView.onStudentRemoved(student));
                }
                catch (Exception err)
                {
                    rollcallUserDefinedSessionView.invokeOnMainThread(() =>
                        rollcallUserDefinedSessionView.onError(err));
                }
            });
        }
    }
}
