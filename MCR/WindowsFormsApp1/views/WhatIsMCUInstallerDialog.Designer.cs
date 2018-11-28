namespace MCR.views
{
    partial class WhatIsMCUInstallerDialog
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 240);
            this.label1.TabIndex = 0;
            this.label1.Text = "個人系統壓縮檔，會將目前系統的所有組件檔案以及\r\n\"與您相關的設置檔案、學生資料檔案\"，\r\n加密並壓縮成一個輕便的exe檔案。\r\n因此您可以更加方便地儲存此exe" +
    "檔案至個人的隨身裝置或雲端上，\r\n而無須去複製整個系統資料夾。\r\n\r\n一旦您啟動此壓縮exe檔，\r\n就會將此次壓縮的內容完整地解壓縮並攤開在其所在資料夾中，\r\n" +
    "供您再次使用點名系統。\r\n(之前的設置及資料都會完整存在於壓縮檔中。)";
            // 
            // WhatIsMCUInstallerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(606, 268);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "WhatIsMCUInstallerDialog";
            this.Text = "個人系統壓縮檔";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}