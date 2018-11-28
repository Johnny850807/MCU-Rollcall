using MCR.fileProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.fileProcessors
{
    public class StubFileProcessor : FileProcessor
    {
        private Dictionary<string, string> filesDict = new Dictionary<string, string>(); //<filename, file content> 

        public string read(string fileName, bool createIfNotExists = true)
        {
            if (createIfNotExists && !filesDict.ContainsKey(fileName))
                filesDict[fileName] = "";
            return filesDict[fileName];
        }

        public void write(string fileName, string content, bool createIfNotExists = true, bool append = false)
        {
            if ((createIfNotExists || append) && !filesDict.ContainsKey(fileName))
                filesDict[fileName] = "";
            if (append)
                filesDict[fileName] += content;
            else
                filesDict[fileName] = content;
        }
    }
}
