using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.utils
{
    public class HtmlTagUtils
    {
        public static string imageElement(string src, string height, string width)
        {
            return String.Format("<img src={0} height={1} width={2}/>", src, height, width);
        }

        public static string br(int lineNumber=1)
        {
            if (lineNumber == 1)
                return "<br/>";
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < lineNumber; i++)
                strb.Append("<br/>");
            return strb.ToString();
        }
    }
}
