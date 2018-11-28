using WinFormAnimation;

namespace MCR.views
{
    partial class StudentsConsolePanel
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
            this.studentsInfoTopPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.sessionsComboBox = new System.Windows.Forms.ComboBox();
            this.studentsInfoTableLayoutPanel = new MCR.views.StudentsTableLayoutPanel();
            this.studentsInfoTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsInfoTopPanel
            // 
            this.studentsInfoTopPanel.BackColor = System.Drawing.Color.White;
            this.studentsInfoTopPanel.Controls.Add(this.label10);
            this.studentsInfoTopPanel.Controls.Add(this.sessionsComboBox);
            this.studentsInfoTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.studentsInfoTopPanel.Location = new System.Drawing.Point(0, 0);
            this.studentsInfoTopPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.studentsInfoTopPanel.Name = "studentsInfoTopPanel";
            this.studentsInfoTopPanel.Size = new System.Drawing.Size(1065, 40);
            this.studentsInfoTopPanel.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(707, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "選擇課程";
            // 
            // sessionsComboBox
            // 
            this.sessionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionsComboBox.FormattingEnabled = true;
            this.sessionsComboBox.Location = new System.Drawing.Point(794, 6);
            this.sessionsComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sessionsComboBox.Name = "sessionsComboBox";
            this.sessionsComboBox.Size = new System.Drawing.Size(162, 20);
            this.sessionsComboBox.TabIndex = 0;
            this.sessionsComboBox.SelectedIndexChanged += new System.EventHandler(this.studentsInfoSessionsComboBox_SelectedIndexChanged);
            // 
            // studentsInfoTableLayoutPanel
            // 
            this.studentsInfoTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentsInfoTableLayoutPanel.AutoScroll = true;
            this.studentsInfoTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.studentsInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.studentsInfoTableLayoutPanel.Location = new System.Drawing.Point(1, 43);
            this.studentsInfoTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.studentsInfoTableLayoutPanel.Name = "studentsInfoTableLayoutPanel";
            this.studentsInfoTableLayoutPanel.onStudentCellClicked = null;
            this.studentsInfoTableLayoutPanel.onStudentCellMouseLeave = null;
            this.studentsInfoTableLayoutPanel.onStudentCellMouseMove = null;
            this.studentsInfoTableLayoutPanel.Size = new System.Drawing.Size(1064, 603);
            this.studentsInfoTableLayoutPanel.TabIndex = 3;
            // 
            // StudentsConsolePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.studentsInfoTopPanel);
            this.Controls.Add(this.studentsInfoTableLayoutPanel);
            this.Name = "StudentsConsolePanel";
            this.Size = new System.Drawing.Size(1065, 646);
            this.Load += new System.EventHandler(this.StudentsConsolePanel_Load);
            this.studentsInfoTopPanel.ResumeLayout(false);
            this.studentsInfoTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel studentsInfoTopPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox sessionsComboBox;
        private StudentsTableLayoutPanel studentsInfoTableLayoutPanel;
    }
}
