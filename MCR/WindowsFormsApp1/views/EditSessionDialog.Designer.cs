﻿namespace MCR
{
    partial class EditSessionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSessionDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.modifySessionNameTextBox = new System.Windows.Forms.TextBox();
            this.confirmModifyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.modifySessionIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "修改課程名稱";
            // 
            // modifySessionNameTextBox
            // 
            this.modifySessionNameTextBox.Location = new System.Drawing.Point(170, 32);
            this.modifySessionNameTextBox.Name = "modifySessionNameTextBox";
            this.modifySessionNameTextBox.Size = new System.Drawing.Size(114, 25);
            this.modifySessionNameTextBox.TabIndex = 1;
            // 
            // confirmModifyButton
            // 
            this.confirmModifyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmModifyButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.confirmModifyButton.Location = new System.Drawing.Point(148, 148);
            this.confirmModifyButton.Name = "confirmModifyButton";
            this.confirmModifyButton.Size = new System.Drawing.Size(136, 40);
            this.confirmModifyButton.TabIndex = 2;
            this.confirmModifyButton.Text = "確認更改";
            this.confirmModifyButton.UseVisualStyleBackColor = true;
            this.confirmModifyButton.Click += new System.EventHandler(this.confirmModifyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "修改課程代號";
            // 
            // modifySessionIdTextBox
            // 
            this.modifySessionIdTextBox.Location = new System.Drawing.Point(170, 88);
            this.modifySessionIdTextBox.Name = "modifySessionIdTextBox";
            this.modifySessionIdTextBox.Size = new System.Drawing.Size(114, 25);
            this.modifySessionIdTextBox.TabIndex = 4;
            // 
            // EditSessionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 210);
            this.Controls.Add(this.modifySessionIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confirmModifyButton);
            this.Controls.Add(this.modifySessionNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSessionDialog";
            this.Text = "編輯課程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modifySessionNameTextBox;
        private System.Windows.Forms.Button confirmModifyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modifySessionIdTextBox;
    }
}