using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR
{
    // This is the example of secret, use yours instead.
    public class Secret
    {
        public static readonly byte[] key =
            new byte[] { 1, 2, 3, 4, 5, 6, 7,
                        8, 9, 10, 11, 12, 13, 14, 15,
                        16, 17, 18, 19, 20, 21, 22, 23,
                        24, 25, 26, 27, 28, 29, 30, 31, 32 };

        public static readonly byte[] iv =
            new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8,
                9, 10, 11, 12, 13, 14, 15 };
    }
}
