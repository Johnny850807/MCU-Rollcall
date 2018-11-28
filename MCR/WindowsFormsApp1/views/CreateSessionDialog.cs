using System;
using System.Windows.Forms;

namespace MCR
{
    partial class CreateSessionDialog : Form
    {
        public string courseNameText { get; set; }
        public string courseIdText { get; set; }

        public CreateSessionDialog()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            courseNameText = courseNameTextBox.Text;
            courseIdText = courseIdTextBox.Text;
        }
    }
}
