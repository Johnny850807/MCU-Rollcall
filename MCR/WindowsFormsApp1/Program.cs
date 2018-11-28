using MCR.views;
using System;
using System.Windows.Forms;

namespace MCR
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EntryForm());
        }
        
    }
}
