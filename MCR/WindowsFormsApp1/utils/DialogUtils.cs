using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR.utils
{
    public class DialogUtils
    {
        public static string createAndShowDialogForChoosingFilePath(string initPath, string defaultFileName)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = initPath;
            sf.FileName = defaultFileName;

            if (sf.ShowDialog() == DialogResult.OK)
               return sf.FileName;
            return null;
        }
    }
}
