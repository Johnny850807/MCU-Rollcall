using MCR.fileProcessors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCR.utils
{
    /// <summary>
    /// The logger serves as making and storing the log messages with its level.
    /// </summary>
    public class Log
    {
        public static bool enable = true;
        public static string logFileName = "log.txt";
        private static FileProcessor fileProcessor = new TxtFileProcessor();
        public static void d(string tag, string debug)
        {
            if (enable)
                queueLog("Debug", tag, debug);
        }

        public static void err(string tag, string error, Exception err = null)
        {
            var errTxt = "";
            if (err != null)
                errTxt = " ( <" + err.GetType() + "> [" + err.Message + "]" + err.StackTrace + ") ";
            if (enable)
                queueLog("Error", tag, error + errTxt);
        }

        private static void queueLog(string level, string tag, string debug)
        {
            ThreadPool.QueueUserWorkItem(o => appendText("[" + level + "] " + DateTime.Now + " [" + tag + "]: " + debug));
        }

        private static void appendText(string txt)
        {
            lock(fileProcessor)
                fileProcessor.write(logFileName, txt, true, true);
        }
    }
}
