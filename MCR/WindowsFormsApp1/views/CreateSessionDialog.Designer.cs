namespace MCR
{
    public partial class CreateSessionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSessionDialog));
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.courseIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(171, 125);
            this.createButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(76, 40);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "確定";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "課程名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "課程代號(可不填)";
            // 
            // courseNameTextBox
            // 
            this.courseNameTextBox.Location = new System.Drawing.Point(147, 34);
            this.courseNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.courseNameTextBox.Name = "courseNameTextBox";
            this.courseNameTextBox.Size = new System.Drawing.Size(100, 25);
            this.courseNameTextBox.TabIndex = 3;
            // 
            // courseIdTextBox
            // 
            this.courseIdTextBox.Location = new System.Drawing.Point(147, 79);
            this.courseIdTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.courseIdTextBox.Name = "courseIdTextBox";
            this.courseIdTextBox.Size = new System.Drawing.Size(100, 25);
            this.courseIdTextBox.TabIndex = 4;
            // 
            // CreateSessionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(283, 190);
            this.Controls.Add(this.courseIdTextBox);
            this.Controls.Add(this.courseNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSessionDialog";
            this.Text = "新增課程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.TextBox courseIdTextBox;
    }
}