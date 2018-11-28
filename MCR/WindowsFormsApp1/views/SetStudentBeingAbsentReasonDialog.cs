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
    public partial class SetStudentBeingAbsentReasonDialog : Form
    {
        private const int COMBOBOX_NONE = 0;
        private const string DEFAULT_REASON_HINT = "自訂理由...";
        public string reason { get; set; }

        public SetStudentBeingAbsentReasonDialog()
        {
            InitializeComponent();
            CenterToScreen();
            usualReasonsCbx.SelectedIndex = COMBOBOX_NONE;
        }
        
        public void usualReasonsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usualReasonsCbx.SelectedIndex == COMBOBOX_NONE)
                customReasomTbx.Enabled = true;
            else
                customReasomTbx.Enabled = false;
        }

        private void customReasomTbx_Click(object sender, EventArgs e)
        {
            //remove the hint once clicked
            if (customReasomTbx.Text == DEFAULT_REASON_HINT)
                customReasomTbx.Text = "";
        }

        private void customReasomTbx_LostFocus(object sender, EventArgs e)
        {
            //replace the hint if empty
            if (string.IsNullOrEmpty(customReasomTbx.Text))
                customReasomTbx.Text = DEFAULT_REASON_HINT;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (usualReasonsCbx.SelectedIndex != COMBOBOX_NONE)
                reason = usualReasonsCbx.GetItemText(usualReasonsCbx.SelectedItem);
            else if (customReasomTbx.Text != DEFAULT_REASON_HINT
                && !string.IsNullOrEmpty(customReasomTbx.Text))
                reason = customReasomTbx.Text;
        }
    }
}
