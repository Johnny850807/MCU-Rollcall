using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR.views
{
    public partial class ExportingMcrInstallerDialog : Form
    {
        private ExportingMcrInstallerDialog()
        {
            InitializeComponent();
        }

        public ExportingMcrInstallerDialog(string filePath) : this()
        {
            this.filePathTxt.Text = filePath; 
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        
    }
}
