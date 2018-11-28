using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR
{
    public interface NetStatesManager
    {
        string getHttpAddress();
        void setPort(int port);
        void setIp(string ip);
        int getPort();
        string getIp();
    }
}
