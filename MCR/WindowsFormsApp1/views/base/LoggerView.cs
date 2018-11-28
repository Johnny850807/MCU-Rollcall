using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.views
{
    public interface LoggerView
    {
        void addNewLog(string log, bool newLine = true);
    }
}
