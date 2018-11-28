using MCR.models;
using System;
using System.Collections.Generic;

namespace MCR.views
{
    public interface SessionManagementView : MainThreadView
    {
        void onUserSessionCreatedSuccessfully(Session session);
        void onUserSessionsGetSuccessfully(List<Session> sessions);
        void onRemoveUserSelectedSessionSuccessfully(Session session);
        void onUserSessionModifySuccessfully(Session session);
        void onError(Exception err);
    }
}
