namespace MCR.views
{
    partial class ExportingSignRecordDialog
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
            this.chooseFileNameBtn = new System.Windows.Forms.Button();
            this.fileNameTbx = new System.Windows.Forms.TextBox();
            this.saveAsTxtBtn = new System.Windows.Forms.Button();
            this.saveAsExcelBtn = new System.Windows.Forms.Button();
            this.saveToGoogleSpreadSheetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseFileNameBtn
            // 
            this.chooseFileNameBtn.Location = new System.Drawing.Point(318, 9);
            this.chooseFileNameBtn.Name = "chooseFileNameBtn";
            this.chooseFileNameBtn.Size = new System.Drawing.Size(86, 33);
            this.chooseFileNameBtn.TabIndex = 0;
            this.chooseFileNameBtn.Text = "選擇位置";
            this.chooseFileNameBtn.UseVisualStyleBackColor = true;
            this.chooseFileNameBtn.Click += new System.EventHandler(this.chooseFileNameBtn_Click);
            // 
            // fileNameTbx
            // 
            this.fileNameTbx.Location = new System.Drawing.Point(12, 12);
            this.fileNameTbx.Name = "fileNameTbx";
            this.fileNameTbx.Size = new System.Drawing.Size(297, 29);
            this.fileNameTbx.TabIndex = 1;
            // 
            // saveAsTxtBtn
            // 
            this.saveAsTxtBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAsTxtBtn.Location = new System.Drawing.Point(12, 59);
            this.saveAsTxtBtn.Name = "saveAsTxtBtn";
            this.saveAsTxtBtn.Size = new System.Drawing.Size(86, 33);
            this.saveAsTxtBtn.TabIndex = 2;
            this.saveAsTxtBtn.Text = "存成 txt";
            this.saveAsTxtBtn.UseVisualStyleBackColor = true;
            this.saveAsTxtBtn.Click += new System.EventHandler(this.saveAsTxtBtn_Click);
            // 
            // saveAsExcelBtn
            // 
            this.saveAsExcelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAsExcelBtn.Location = new System.Drawing.Point(110, 59);
            this.saveAsExcelBtn.Name = "saveAsExcelBtn";
            this.saveAsExcelBtn.Size = new System.Drawing.Size(103, 33);
            this.saveAsExcelBtn.TabIndex = 3;
            this.saveAsExcelBtn.Text = "存成 Excel";
            this.saveAsExcelBtn.UseVisualStyleBackColor = true;
            this.saveAsExcelBtn.Click += new System.EventHandler(this.saveAsExcelBtn_Click);
            // 
            // saveToGoogleSpreadSheetBtn
            // 
            this.saveToGoogleSpreadSheetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveToGoogleSpreadSheetBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.saveToGoogleSpreadSheetBtn.Location = new System.Drawing.Point(223, 59);
            this.saveToGoogleSpreadSheetBtn.Name = "saveToGoogleSpreadSheetBtn";
            this.saveToGoogleSpreadSheetBtn.Size = new System.Drawing.Size(181, 33);
            this.saveToGoogleSpreadSheetBtn.TabIndex = 4;
            this.saveToGoogleSpreadSheetBtn.Text = "存到  Google Excel 試算表";
            this.saveToGoogleSpreadSheetBtn.UseVisualStyleBackColor = true;
            this.saveToGoogleSpreadSheetBtn.Click += new System.EventHandler(this.saveToGoogleSpreadSheetBtn_Click);
            // 
            // ExportingSignRecordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 108);
            this.Controls.Add(this.saveToGoogleSpreadSheetBtn);
            this.Controls.Add(this.saveAsExcelBtn);
            this.Controls.Add(this.saveAsTxtBtn);
            this.Controls.Add(this.fileNameTbx);
            this.Controls.Add(this.chooseFileNameBtn);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ExportingSignRecordDialog";
            this.Text = "ExportingSignRecordDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFileNameBtn;
        private System.Windows.Forms.TextBox fileNameTbx;
        private System.Windows.Forms.Button saveAsTxtBtn;
        private System.Windows.Forms.Button saveAsExcelBtn;
        private System.Windows.Forms.Button saveToGoogleSpreadSheetBtn;
    }
}