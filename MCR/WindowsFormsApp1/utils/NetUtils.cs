using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MCR.utils
{
    public class NetUtils
    {
        /// <summary>
        /// 幹這個函數會把你防火牆關了！
        /// 太鳥了吧！
        /// </summary>
        public static void turnOffFireWall()
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            dynamic mgr = Activator.CreateInstance(netFwPolicy2Type);
            mgr.FirewallEnabled[2] = false;
            mgr.FirewallEnabled[4] = false;
        }


        public static void enableRollcallServerPort(string ip, int port)
        {
            string ht = "http://" + ip + ":" + port + "/";
            string args = string.Format("http add urlacl url={0}", ht) + "user=everyone listen=yes";
            ProcessStartInfo psi = new ProcessStartInfo("netsh.exe");
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;
            psi.Arguments = args;
            Process.Start(psi);
        }
        
        public static string getIp()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            Array.Sort(localIP, (x, y) => isPrivateIp(x) ? 1 : -1);
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString();
            }

            throw new Exception("getIp error.");
        }

        public static bool isPrivateIp(IPAddress address)
        {
            return isPrivateIp(address.ToString());
        }

        public static bool isPrivateIp(string address)
        {
            if (address.StartsWith("192.168") ||
                address.StartsWith("10"))
                return true;
            if (address.StartsWith("172"))
            {
                // 172.16.0.0-172.31.255.255 is private
                int secondNum = Convert.ToInt32(address.Split('.')[1]);
                return secondNum >= 16 && secondNum <= 31;
            }
            return false;
        }

        internal static string[] getIps()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            Array.Sort(localIP, (x, y) => isPrivateIp(x) ? 1 : -1);
            return localIP.Where(l => l.AddressFamily == AddressFamily.InterNetwork)
                        .Select(l => l.ToString()).ToArray();
        }
    }
}
