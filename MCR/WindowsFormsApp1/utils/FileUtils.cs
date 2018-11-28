using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.utils
{
    public class FileUtils
    {
        public static string createDirectoryIfNotExists(string directoryName)
        {
            string curDir = Environment.CurrentDirectory;
            string defaultOutputDir = curDir + "\\" + directoryName;
            Directory.CreateDirectory(defaultOutputDir);
            return defaultOutputDir;
        }
    }
}
