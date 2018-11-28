using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.utils
{
    public class MingChuanUtils
    {
        public static string getEPortfolioProfileImageUrl(string studentId)
        {
            return @"https://www.mcu.edu.tw/student/%E6%A0%A1%E5%9C%92IC%E5%8D%A1%E7%85%A7%E7%89%87%E6%AA%94/student/" + studentId + ".jpg";
        }
    }
}
