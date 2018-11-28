using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.fileProcessors
{
    public class TxtFileProcessor : FileProcessor
    {
        public virtual string read(string fileName, bool createIfNotExists = true)
        {
            using (FileStream fs = new FileStream(
                fileName,
                createIfNotExists ? FileMode.OpenOrCreate : FileMode.Open,
                FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
                return sr.ReadToEnd().Trim();
        }

        public virtual void write(string fileName, string content, 
            bool createIfNotExists = true, bool append = false)
        {
            if (File.Exists(fileName) && !append)
                File.Delete(fileName);
            using (FileStream fs = new FileStream(
                fileName,
                append ? FileMode.Append : createIfNotExists ? FileMode.OpenOrCreate : FileMode.Open,
                FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
                sw.WriteLine(content.Trim().Trim());
        }
    }
}
