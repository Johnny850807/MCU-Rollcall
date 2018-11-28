namespace MCR.views
{
    partial class ServerSettingDialog
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
            this.okBtn = new System.Windows.Forms.Button();
            this.hintTxt = new System.Windows.Forms.Label();
            this.portTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(152, 39);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "套用";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // hintTxt
            // 
            this.hintTxt.AutoSize = true;
            this.hintTxt.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hintTxt.Location = new System.Drawing.Point(11, 11);
            this.hintTxt.Name = "hintTxt";
            this.hintTxt.Size = new System.Drawing.Size(105, 17);
            this.hintTxt.TabIndex = 1;
            this.hintTxt.Text = "伺服器偵聽 port:";
            // 
            // portTbx
            // 
            this.portTbx.Location = new System.Drawing.Point(126, 9);
            this.portTbx.Name = "portTbx";
            this.portTbx.Size = new System.Drawing.Size(100, 22);
            this.portTbx.TabIndex = 2;
            this.portTbx.TextChanged += new System.EventHandler(this.portTbx_TextChanged);
            // 
            // ServerSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 66);
            this.Controls.Add(this.portTbx);
            this.Controls.Add(this.hintTxt);
            this.Controls.Add(this.okBtn);
            this.MinimumSize = new System.Drawing.Size(250, 105);
            this.Name = "ServerSettingDialog";
            this.Text = "伺服器設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label hintTxt;
        private System.Windows.Forms.TextBox portTbx;
    }
}