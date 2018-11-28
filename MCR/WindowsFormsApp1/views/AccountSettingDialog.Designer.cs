namespace MCR
{
    partial class AccountSettingDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accountEd = new System.Windows.Forms.TextBox();
            this.passwordEd = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號設置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(23, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼設置";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "此功能將會為您自動載入帳密，\r\n並且自動輸入在網頁表單上。\r\n而此帳密皆會以加密的形式儲存於本機上。";
            // 
            // accountEd
            // 
            this.accountEd.Location = new System.Drawing.Point(128, 77);
            this.accountEd.Margin = new System.Windows.Forms.Padding(2);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(169, 29);
            this.accountEd.TabIndex = 4;
            // 
            // passwordEd
            // 
            this.passwordEd.Location = new System.Drawing.Point(128, 120);
            this.passwordEd.Margin = new System.Windows.Forms.Padding(2);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(169, 29);
            this.passwordEd.TabIndex = 5;
            // 
            // confirmBtn
            // 
            this.confirmBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmBtn.Location = new System.Drawing.Point(240, 173);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(57, 32);
            this.confirmBtn.TabIndex = 6;
            this.confirmBtn.Text = "確定";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // AccountSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 216);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.passwordEd);
            this.Controls.Add(this.accountEd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AccountSettingDialog";
            this.Text = "教師帳密設置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accountEd;
        private System.Windows.Forms.TextBox passwordEd;
        private System.Windows.Forms.Button confirmBtn;
    }
}