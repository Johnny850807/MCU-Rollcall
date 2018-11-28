using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.adapters
{
    /// <summary>
    /// Interface of two functions processing the text,
    /// but which both are the inverse functions of each other.
    /// </summary>
    public interface TextParser
    {
        string parse(string txt);
        string deparse(string txt);
    }
}
