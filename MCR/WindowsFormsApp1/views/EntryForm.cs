using MCR.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
        }

        private void showMCURollCallButton_Click(object sender, EventArgs e)
        {
            var factory = new ReleaseMcrFactory();
            this.Hide();
            var MainForm = new MainForm(factory, new RollcallWebPanel(factory));
            MainForm.Closed += (s, args) => this.Close();
            MainForm.Show();
        }

        private void showUserDefinedButton_Click(object sender, EventArgs e)
        {
            var factory = new ReleaseMcrFactory();
            this.Hide();
            var rollcallUserDefinedSessionPanel = new RollcallUserDefinedSessionPanel(factory);
            var MainForm = new MainForm(factory, rollcallUserDefinedSessionPanel);
            rollcallUserDefinedSessionPanel.setRollcallView(MainForm);

            MainForm.Closed += (s, args) => this.Close();
            MainForm.Show();
        }
    }
}
