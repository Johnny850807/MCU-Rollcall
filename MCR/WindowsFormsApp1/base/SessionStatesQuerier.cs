using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    public interface SessionStatesQuerier
    {
        bool isRollcallSessionStarted();
        Session getCurrentSession();
    }
}
