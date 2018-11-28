using MCR.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.tools
{
    /// <summary>
    /// We need an instance to manage the state of the net instead of using static method!
    /// </summary>
    public class NetStatesManagerImp : NetStatesManager
    {
        private string ip = NetUtils.getIp();

        public int getPort()
        {
            return UserConfig.getInstance().getServerListeningPort();
        }

        public void setPort(int port)
        {
            UserConfig.getInstance().setServerListeningPort(port);
        }

        public string getIp()
        {
            return ip;
        }

        public string getHttpAddress()
        {
            return "http://" + ip + ":" + getPort() + "/";
        }

        public void setIp(string ip)
        {
            this.ip = ip;
        }
    }
}
