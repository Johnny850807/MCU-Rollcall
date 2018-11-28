using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.fileProcessors
{
    public interface FileProcessor
    {
        string read(string fileName, bool createIfNotExists = true);
        void write(string fileName, string content, bool createIfNotExists = true, bool append = false);
    }
}
