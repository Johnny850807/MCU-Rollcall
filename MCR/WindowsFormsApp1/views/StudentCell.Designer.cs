namespace MCR
{
    partial class StudentCell
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
            this.studentNameTxt = new System.Windows.Forms.Label();
            this.studentIdTxt = new System.Windows.Forms.Label();
            this.studentPicture = new System.Windows.Forms.PictureBox();
            this.stateTxt = new System.Windows.Forms.Label();
            this.ipTxt = new System.Windows.Forms.Label();
            this.absentReasonTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNameTxt
            // 
            this.studentNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.studentNameTxt.AutoSize = true;
            this.studentNameTxt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.studentNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.studentNameTxt.Location = new System.Drawing.Point(34, 132);
            this.studentNameTxt.Name = "studentNameTxt";
            this.studentNameTxt.Size = new System.Drawing.Size(42, 21);
            this.studentNameTxt.TabIndex = 1;
            this.studentNameTxt.Text = "姓名";
            this.studentNameTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentIdTxt
            // 
            this.studentIdTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.studentIdTxt.AutoSize = true;
            this.studentIdTxt.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.studentIdTxt.Location = new System.Drawing.Point(39, 154);
            this.studentIdTxt.Name = "studentIdTxt";
            this.studentIdTxt.Size = new System.Drawing.Size(32, 16);
            this.studentIdTxt.TabIndex = 2;
            this.studentIdTxt.Text = "學號";
            this.studentIdTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentPicture
            // 
            this.studentPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.studentPicture.Location = new System.Drawing.Point(24, 42);
            this.studentPicture.MaximumSize = new System.Drawing.Size(60, 65);
            this.studentPicture.MinimumSize = new System.Drawing.Size(60, 65);
            this.studentPicture.Name = "studentPicture";
            this.studentPicture.Size = new System.Drawing.Size(60, 65);
            this.studentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.studentPicture.TabIndex = 0;
            this.studentPicture.TabStop = false;
            this.studentPicture.Click += new System.EventHandler(this.StudentCell_Click);
            this.studentPicture.MouseLeave += new System.EventHandler(this.StudentCell_MouseLeave);
            this.studentPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StudentCell_MouseMove);
            // 
            // stateTxt
            // 
            this.stateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stateTxt.AutoSize = true;
            this.stateTxt.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.stateTxt.ForeColor = System.Drawing.Color.Green;
            this.stateTxt.Location = new System.Drawing.Point(28, 4);
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.Size = new System.Drawing.Size(50, 18);
            this.stateTxt.TabIndex = 3;
            this.stateTxt.Text = "以簽到";
            this.stateTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipTxt
            // 
            this.ipTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipTxt.AutoSize = true;
            this.ipTxt.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.ipTxt.ForeColor = System.Drawing.Color.Blue;
            this.ipTxt.Location = new System.Drawing.Point(20, 114);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(73, 16);
            this.ipTxt.TabIndex = 4;
            this.ipTxt.Text = "192.168.0.2";
            this.ipTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // absentReasonTxt
            // 
            this.absentReasonTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.absentReasonTxt.AutoSize = true;
            this.absentReasonTxt.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.absentReasonTxt.ForeColor = System.Drawing.Color.Firebrick;
            this.absentReasonTxt.Location = new System.Drawing.Point(34, 24);
            this.absentReasonTxt.Name = "absentReasonTxt";
            this.absentReasonTxt.Size = new System.Drawing.Size(40, 15);
            this.absentReasonTxt.TabIndex = 5;
            this.absentReasonTxt.Text = "請病假";
            this.absentReasonTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StudentCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.absentReasonTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.stateTxt);
            this.Controls.Add(this.studentIdTxt);
            this.Controls.Add(this.studentNameTxt);
            this.Controls.Add(this.studentPicture);
            this.MaximumSize = new System.Drawing.Size(111, 176);
            this.MinimumSize = new System.Drawing.Size(111, 176);
            this.Name = "StudentCell";
            this.Size = new System.Drawing.Size(111, 176);
            this.Click += new System.EventHandler(this.StudentCell_Click);
            this.MouseLeave += new System.EventHandler(this.StudentCell_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StudentCell_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox studentPicture;
        private System.Windows.Forms.Label studentNameTxt;
        private System.Windows.Forms.Label studentIdTxt;
        private System.Windows.Forms.Label stateTxt;
        private System.Windows.Forms.Label ipTxt;
        private System.Windows.Forms.Label absentReasonTxt;
    }
}
