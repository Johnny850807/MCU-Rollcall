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
    public partial class ServerSettingDialog : Form
    {
        private NetStatesManager netStatesManager;
        public ServerSettingDialog(NetStatesManager netStatesManager)
        {
            this.netStatesManager = netStatesManager;
            InitializeComponent();
            var port = netStatesManager.getPort();
            portTbx.Text = Convert.ToString(port);
        }

        private void portTbx_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(portTbx.Text) && 
                !char.IsDigit(portTbx.Text.Last()))
                portTbx.Text.Remove(portTbx.Text.Length-1);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(portTbx.Text);
            netStatesManager.setPort(port);
            MessageBox.Show("設置完成！伺服器將偵聽 " + port + " port。請重啟伺服器。");
        }
    }
}
