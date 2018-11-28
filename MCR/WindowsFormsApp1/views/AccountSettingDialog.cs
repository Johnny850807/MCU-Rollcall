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
    public partial class AccountSettingDialog : Form
    {
        public string account { get; set; }
        public string password { get; set; }
        public AccountSettingDialog()
        {
            InitializeComponent();
            UserConfig userConfig = UserConfig.getInstance();
            accountEd.Text = userConfig.getAccount();
            passwordEd.Text = userConfig.getPassword();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            account = accountEd.Text;
            password = passwordEd.Text;
        }
    }
}
