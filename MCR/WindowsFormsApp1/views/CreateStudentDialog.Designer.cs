namespace MCR
{
    partial class AddStudentDialog
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
            this.addStudentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addStudentIdTextBox = new System.Windows.Forms.TextBox();
            this.addStudentNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addStudentButton
            // 
            this.addStudentButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addStudentButton.Location = new System.Drawing.Point(132, 154);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(84, 38);
            this.addStudentButton.TabIndex = 0;
            this.addStudentButton.Text = "確認新增";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "學號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(28, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // addStudentIdTextBox
            // 
            this.addStudentIdTextBox.Location = new System.Drawing.Point(101, 43);
            this.addStudentIdTextBox.Name = "addStudentIdTextBox";
            this.addStudentIdTextBox.Size = new System.Drawing.Size(115, 25);
            this.addStudentIdTextBox.TabIndex = 3;
            // 
            // addStudentNameTextBox
            // 
            this.addStudentNameTextBox.Location = new System.Drawing.Point(101, 100);
            this.addStudentNameTextBox.Name = "addStudentNameTextBox";
            this.addStudentNameTextBox.Size = new System.Drawing.Size(115, 25);
            this.addStudentNameTextBox.TabIndex = 4;
            // 
            // AddStudentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 212);
            this.Controls.Add(this.addStudentNameTextBox);
            this.Controls.Add(this.addStudentIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addStudentButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStudentDialog";
            this.Text = "新增學生";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addStudentIdTextBox;
        private System.Windows.Forms.TextBox addStudentNameTextBox;
    }
}