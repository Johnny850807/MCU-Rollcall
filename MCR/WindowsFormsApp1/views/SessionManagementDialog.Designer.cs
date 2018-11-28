namespace MCR
{
    partial class SessionManagementDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionManagementDialog));
            this.createCourseButton = new System.Windows.Forms.Button();
            this.sessionManagementDialogListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadSelectCourseButton = new System.Windows.Forms.Button();
            this.deleteSessionButton = new System.Windows.Forms.Button();
            this.editSessionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createCourseButton
            // 
            this.createCourseButton.Location = new System.Drawing.Point(21, 43);
            this.createCourseButton.Name = "createCourseButton";
            this.createCourseButton.Size = new System.Drawing.Size(93, 35);
            this.createCourseButton.TabIndex = 0;
            this.createCourseButton.Text = "創建課程";
            this.createCourseButton.UseVisualStyleBackColor = true;
            this.createCourseButton.Click += new System.EventHandler(this.createCourseButton_Click);
            // 
            // sessionManagementDialogListView
            // 
            this.sessionManagementDialogListView.BackColor = System.Drawing.SystemColors.Window;
            this.sessionManagementDialogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.sessionManagementDialogListView.Location = new System.Drawing.Point(21, 111);
            this.sessionManagementDialogListView.MultiSelect = false;
            this.sessionManagementDialogListView.Name = "sessionManagementDialogListView";
            this.sessionManagementDialogListView.Size = new System.Drawing.Size(522, 351);
            this.sessionManagementDialogListView.TabIndex = 1;
            this.sessionManagementDialogListView.UseCompatibleStateImageBehavior = false;
            this.sessionManagementDialogListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "課程名稱";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "課程代號";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "學生數量";
            this.columnHeader3.Width = 108;
            // 
            // loadSelectCourseButton
            // 
            this.loadSelectCourseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadSelectCourseButton.Location = new System.Drawing.Point(425, 489);
            this.loadSelectCourseButton.Name = "loadSelectCourseButton";
            this.loadSelectCourseButton.Size = new System.Drawing.Size(101, 32);
            this.loadSelectCourseButton.TabIndex = 2;
            this.loadSelectCourseButton.Text = "載入選取課程";
            this.loadSelectCourseButton.UseVisualStyleBackColor = true;
            this.loadSelectCourseButton.Click += new System.EventHandler(this.loadSelectCourseButton_Click);
            // 
            // deleteSessionButton
            // 
            this.deleteSessionButton.Location = new System.Drawing.Point(136, 43);
            this.deleteSessionButton.Name = "deleteSessionButton";
            this.deleteSessionButton.Size = new System.Drawing.Size(90, 35);
            this.deleteSessionButton.TabIndex = 3;
            this.deleteSessionButton.Text = "刪除課程";
            this.deleteSessionButton.UseVisualStyleBackColor = true;
            this.deleteSessionButton.Click += new System.EventHandler(this.deleteSessionButton_Click);
            // 
            // editSessionButton
            // 
            this.editSessionButton.Location = new System.Drawing.Point(277, 43);
            this.editSessionButton.Name = "editSessionButton";
            this.editSessionButton.Size = new System.Drawing.Size(86, 35);
            this.editSessionButton.TabIndex = 4;
            this.editSessionButton.Text = "編輯課程";
            this.editSessionButton.UseVisualStyleBackColor = true;
            this.editSessionButton.Click += new System.EventHandler(this.editSessionButton_Click);
            // 
            // SessionManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(578, 551);
            this.Controls.Add(this.editSessionButton);
            this.Controls.Add(this.deleteSessionButton);
            this.Controls.Add(this.loadSelectCourseButton);
            this.Controls.Add(this.sessionManagementDialogListView);
            this.Controls.Add(this.createCourseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionManagementDialog";
            this.Text = "課程管理";
            this.Load += new System.EventHandler(this.SessionManagementDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createCourseButton;
        private System.Windows.Forms.ListView sessionManagementDialogListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button loadSelectCourseButton;
        private System.Windows.Forms.Button deleteSessionButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button editSessionButton;
    }
}