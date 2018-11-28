using MCR.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR
{
    public partial class EditSessionDialog : Form
    {
        public Session session; 

        public EditSessionDialog()
        {
            InitializeComponent();
            session = new Session();
        }

        private void confirmModifyButton_Click(object sender, EventArgs e)
        {
            if (modifySessionNameTextBox.Text.Length > 0)
            {
                this.session.name = modifySessionNameTextBox.Text;
                this.session.subjectNumber = modifySessionIdTextBox.Text;
            }
            else
                MessageBox.Show("請確實填寫");
            
        }
    }
}
