using MCR.models;
using MCR.models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    class SessionManagementPresenter
    {
        private McrRepository mcrRepository;
        private SessionManagementView sessionManagementView;

        public SessionManagementPresenter(McrRepository mcrRepository)
        {
            this.mcrRepository = mcrRepository;
        }

        public void setSessionManagementView(SessionManagementView customizeView)
        {
            this.sessionManagementView = customizeView;
        }
        
        public void createSession(Session session)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    session = mcrRepository.createSession(session);
                    sessionManagementView.invokeOnMainThread(() => 
                        sessionManagementView.onUserSessionCreatedSuccessfully(session));
                }
                catch (Exception err) { sessionManagementView.invokeOnMainThread(() => sessionManagementView.onError(err)); }
            });
        }
        public void onGetUserSessions()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var sessions = mcrRepository.getSessions();
                    sessionManagementView.invokeOnMainThread(() => 
                        sessionManagementView.onUserSessionsGetSuccessfully(sessions));
                }
                catch (Exception err) { sessionManagementView.invokeOnMainThread(() => sessionManagementView.onError(err)); }
            });

        }
        public void removeUserSelectedSession(Session session)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    mcrRepository.removeSession(session.id);
                    sessionManagementView.invokeOnMainThread(() =>
                        sessionManagementView.onRemoveUserSelectedSessionSuccessfully(session));
                }
                catch (Exception err) { sessionManagementView.invokeOnMainThread(() => sessionManagementView.onError(err)); }
            });
        }

        public void editUserSelectedSession(Session session)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    mcrRepository.updateSession(session);
                    sessionManagementView.invokeOnMainThread(() =>
                        sessionManagementView.onUserSessionModifySuccessfully(session));
                }
                catch (Exception err) { sessionManagementView.invokeOnMainThread(() => sessionManagementView.onError(err)); }
            });
        }
    }
}
