namespace MCR.views
{
    partial class SetStudentBeingAbsentReasonDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usualReasonsCbx = new System.Windows.Forms.ComboBox();
            this.usualReasonsTxt = new System.Windows.Forms.Label();
            this.customReasomTbx = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usualReasonsCbx
            // 
            this.usualReasonsCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usualReasonsCbx.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.usualReasonsCbx.FormattingEnabled = true;
            this.usualReasonsCbx.Items.AddRange(new object[] {
            "不選擇",
            "病假",
            "上班",
            "晚到",
            "事假",
            "公假",
            "嚴重缺席"});
            this.usualReasonsCbx.Location = new System.Drawing.Point(103, 8);
            this.usualReasonsCbx.Name = "usualReasonsCbx";
            this.usualReasonsCbx.Size = new System.Drawing.Size(121, 24);
            this.usualReasonsCbx.TabIndex = 0;
            this.usualReasonsCbx.SelectedIndexChanged += new System.EventHandler(this.usualReasonsCbx_SelectedIndexChanged);
            // 
            // usualReasonsTxt
            // 
            this.usualReasonsTxt.AutoSize = true;
            this.usualReasonsTxt.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.usualReasonsTxt.Location = new System.Drawing.Point(10, 10);
            this.usualReasonsTxt.Name = "usualReasonsTxt";
            this.usualReasonsTxt.Size = new System.Drawing.Size(86, 17);
            this.usualReasonsTxt.TabIndex = 1;
            this.usualReasonsTxt.Text = "常用請假理由";
            // 
            // customReasomTbx
            // 
            this.customReasomTbx.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customReasomTbx.Location = new System.Drawing.Point(12, 42);
            this.customReasomTbx.Name = "customReasomTbx";
            this.customReasomTbx.Size = new System.Drawing.Size(210, 23);
            this.customReasomTbx.TabIndex = 2;
            this.customReasomTbx.Text = "自訂理由...";
            this.customReasomTbx.Click += new System.EventHandler(this.customReasomTbx_Click);
            this.customReasomTbx.LostFocus += new System.EventHandler(this.customReasomTbx_LostFocus);
            // 
            // okBtn
            // 
            this.okBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(123, 75);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(101, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "設置請假理由";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // SetStudentBeingAbsentReasonDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 106);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.customReasomTbx);
            this.Controls.Add(this.usualReasonsTxt);
            this.Controls.Add(this.usualReasonsCbx);
            this.Name = "SetStudentBeingAbsentReasonDialog";
            this.Text = "設置請假理由";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usualReasonsCbx;
        private System.Windows.Forms.Label usualReasonsTxt;
        private System.Windows.Forms.TextBox customReasomTbx;
        private System.Windows.Forms.Button okBtn;
    }
}