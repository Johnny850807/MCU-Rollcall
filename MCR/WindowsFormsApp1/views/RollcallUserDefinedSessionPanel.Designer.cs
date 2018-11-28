namespace MCR.views
{
    partial class RollcallUserDefinedSessionPanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userDefinedSessionParentPanel = new System.Windows.Forms.Panel();
            this.topConsolePanel = new System.Windows.Forms.Panel();
            this.CountSignInStudentsLabel = new System.Windows.Forms.Label();
            this.courseName = new System.Windows.Forms.Label();
            this.studentsTablePanel = new MCR.views.StudentsTableLayoutPanel();
            this.userDefinedSessionParentPanel.SuspendLayout();
            this.topConsolePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userDefinedSessionParentPanel
            // 
            this.userDefinedSessionParentPanel.BackColor = System.Drawing.Color.Transparent;
            this.userDefinedSessionParentPanel.Controls.Add(this.topConsolePanel);
            this.userDefinedSessionParentPanel.Controls.Add(this.studentsTablePanel);
            this.userDefinedSessionParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDefinedSessionParentPanel.Location = new System.Drawing.Point(0, 0);
            this.userDefinedSessionParentPanel.Name = "userDefinedSessionParentPanel";
            this.userDefinedSessionParentPanel.Size = new System.Drawing.Size(1061, 642);
            this.userDefinedSessionParentPanel.TabIndex = 1;
            this.userDefinedSessionParentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userDefinedSessionParentPanel_Paint);
            // 
            // topConsolePanel
            // 
            this.topConsolePanel.Controls.Add(this.CountSignInStudentsLabel);
            this.topConsolePanel.Controls.Add(this.courseName);
            this.topConsolePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topConsolePanel.Location = new System.Drawing.Point(0, 0);
            this.topConsolePanel.Name = "topConsolePanel";
            this.topConsolePanel.Size = new System.Drawing.Size(1061, 35);
            this.topConsolePanel.TabIndex = 1;
            // 
            // CountSignInStudentsLabel
            // 
            this.CountSignInStudentsLabel.AutoSize = true;
            this.CountSignInStudentsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountSignInStudentsLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CountSignInStudentsLabel.Location = new System.Drawing.Point(179, 6);
            this.CountSignInStudentsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CountSignInStudentsLabel.Name = "CountSignInStudentsLabel";
            this.CountSignInStudentsLabel.Size = new System.Drawing.Size(48, 22);
            this.CountSignInStudentsLabel.TabIndex = 15;
            this.CountSignInStudentsLabel.Text = "0 / 0 ";
            // 
            // courseName
            // 
            this.courseName.AutoSize = true;
            this.courseName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.courseName.Location = new System.Drawing.Point(19, 8);
            this.courseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.courseName.Name = "courseName";
            this.courseName.Size = new System.Drawing.Size(73, 20);
            this.courseName.TabIndex = 9;
            this.courseName.Text = "課程名稱";
            // 
            // studentsTablePanel
            // 
            this.studentsTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentsTablePanel.AutoScroll = true;
            this.studentsTablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(73)))));
            this.studentsTablePanel.ColumnCount = 1;
            this.studentsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.studentsTablePanel.Location = new System.Drawing.Point(0, 36);
            this.studentsTablePanel.Name = "studentsTablePanel";
            this.studentsTablePanel.onStudentCellClicked = null;
            this.studentsTablePanel.onStudentCellMouseLeave = null;
            this.studentsTablePanel.onStudentCellMouseMove = null;
            this.studentsTablePanel.RowCount = 1;
            this.studentsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.studentsTablePanel.Size = new System.Drawing.Size(1061, 606);
            this.studentsTablePanel.TabIndex = 2;
            // 
            // RollcallUserDefinedSessionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userDefinedSessionParentPanel);
            this.Name = "RollcallUserDefinedSessionPanel";
            this.Size = new System.Drawing.Size(1061, 642);
            this.userDefinedSessionParentPanel.ResumeLayout(false);
            this.topConsolePanel.ResumeLayout(false);
            this.topConsolePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userDefinedSessionParentPanel;
        private System.Windows.Forms.Panel topConsolePanel;
        private System.Windows.Forms.Label courseName;
        private StudentsTableLayoutPanel studentsTablePanel;
        private System.Windows.Forms.Label CountSignInStudentsLabel;
    }
}
