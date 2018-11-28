using MCR.fileProcessors;
using MCR.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.adapters
{
    public class RijndaelEncryptor : Encryptor
    {
        public string deparse(string txt)
        {
            if (txt.Length == 0)
                return "";
            return RijndaelUtils.decrypt(txt, Secret.key, Secret.iv);
        }

        public string parse(string txt)
        {
            if (txt.Length == 0)
                return "";
            return RijndaelUtils.encrypt(txt, Secret.key, Secret.iv);
        }
    }
}
