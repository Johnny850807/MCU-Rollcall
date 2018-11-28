namespace MCR.views
{
    partial class QRCodeConsolePanel
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
            this.rightParentPanel = new System.Windows.Forms.Panel();
            this.qrCodeUpdateFrequencyBar = new System.Windows.Forms.TrackBar();
            this.qRCodeUpdateFrequencyTxt = new System.Windows.Forms.Label();
            this.qrCodeCountDownTxt = new System.Windows.Forms.Label();
            this.qrCodeImg = new System.Windows.Forms.PictureBox();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.qrcodeButton = new System.Windows.Forms.Button();
            this.rightParentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeUpdateFrequencyBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // rightParentPanel
            // 
            this.rightParentPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rightParentPanel.Controls.Add(this.qrCodeUpdateFrequencyBar);
            this.rightParentPanel.Controls.Add(this.qRCodeUpdateFrequencyTxt);
            this.rightParentPanel.Controls.Add(this.qrCodeCountDownTxt);
            this.rightParentPanel.Controls.Add(this.qrCodeImg);
            this.rightParentPanel.Controls.Add(this.logsTextBox);
            this.rightParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightParentPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rightParentPanel.Location = new System.Drawing.Point(0, 40);
            this.rightParentPanel.Name = "rightParentPanel";
            this.rightParentPanel.Padding = new System.Windows.Forms.Padding(2);
            this.rightParentPanel.Size = new System.Drawing.Size(305, 635);
            this.rightParentPanel.TabIndex = 3;
            // 
            // qrCodeUpdateFrequencyBar
            // 
            this.qrCodeUpdateFrequencyBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.qrCodeUpdateFrequencyBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrCodeUpdateFrequencyBar.Location = new System.Drawing.Point(2, 62);
            this.qrCodeUpdateFrequencyBar.Minimum = 1;
            this.qrCodeUpdateFrequencyBar.Name = "qrCodeUpdateFrequencyBar";
            this.qrCodeUpdateFrequencyBar.Size = new System.Drawing.Size(301, 56);
            this.qrCodeUpdateFrequencyBar.TabIndex = 2;
            this.qrCodeUpdateFrequencyBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.qrCodeUpdateFrequencyBar.Value = 8;
            this.qrCodeUpdateFrequencyBar.Scroll += new System.EventHandler(this.qrCodeUpdateFrequencyBar_Scroll);
            // 
            // qRCodeUpdateFrequencyTxt
            // 
            this.qRCodeUpdateFrequencyTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.qRCodeUpdateFrequencyTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.qRCodeUpdateFrequencyTxt.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.qRCodeUpdateFrequencyTxt.Location = new System.Drawing.Point(2, 42);
            this.qRCodeUpdateFrequencyTxt.Name = "qRCodeUpdateFrequencyTxt";
            this.qRCodeUpdateFrequencyTxt.Size = new System.Drawing.Size(301, 20);
            this.qRCodeUpdateFrequencyTxt.TabIndex = 7;
            this.qRCodeUpdateFrequencyTxt.Text = "QR Code 更新頻率(8秒)";
            this.qRCodeUpdateFrequencyTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qrCodeCountDownTxt
            // 
            this.qrCodeCountDownTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.qrCodeCountDownTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrCodeCountDownTxt.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.qrCodeCountDownTxt.ForeColor = System.Drawing.Color.Red;
            this.qrCodeCountDownTxt.Location = new System.Drawing.Point(2, 2);
            this.qrCodeCountDownTxt.Name = "qrCodeCountDownTxt";
            this.qrCodeCountDownTxt.Size = new System.Drawing.Size(301, 40);
            this.qrCodeCountDownTxt.TabIndex = 9;
            this.qrCodeCountDownTxt.Text = "---- 更新倒數 ----";
            this.qrCodeCountDownTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qrCodeImg
            // 
            this.qrCodeImg.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.qrCodeImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.qrCodeImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrCodeImg.Image = global::MCR.Properties.Resources.mcu_logo;
            this.qrCodeImg.ImageLocation = "";
            this.qrCodeImg.Location = new System.Drawing.Point(2, 2);
            this.qrCodeImg.Name = "qrCodeImg";
            this.qrCodeImg.Padding = new System.Windows.Forms.Padding(3);
            this.qrCodeImg.Size = new System.Drawing.Size(301, 420);
            this.qrCodeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qrCodeImg.TabIndex = 8;
            this.qrCodeImg.TabStop = false;
            this.qrCodeImg.SizeChanged += new System.EventHandler(this.qrCodeImg_SizeChanged);
            // 
            // logsTextBox
            // 
            this.logsTextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.logsTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logsTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.logsTextBox.ForeColor = System.Drawing.Color.Aqua;
            this.logsTextBox.Location = new System.Drawing.Point(2, 422);
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ShortcutsEnabled = false;
            this.logsTextBox.Size = new System.Drawing.Size(301, 211);
            this.logsTextBox.TabIndex = 3;
            // 
            // qrcodeButton
            // 
            this.qrcodeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.qrcodeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrcodeButton.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.qrcodeButton.Location = new System.Drawing.Point(0, 0);
            this.qrcodeButton.Margin = new System.Windows.Forms.Padding(0);
            this.qrcodeButton.Name = "qrcodeButton";
            this.qrcodeButton.Size = new System.Drawing.Size(305, 40);
            this.qrcodeButton.TabIndex = 1;
            this.qrcodeButton.Text = "運行點名伺服器";
            this.qrcodeButton.UseVisualStyleBackColor = false;
            this.qrcodeButton.Click += new System.EventHandler(this.qrcodeBtn_Click);
            // 
            // QRCodeConsolePanel
            // 
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.rightParentPanel);
            this.Controls.Add(this.qrcodeButton);
            this.Name = "QRCodeConsolePanel";
            this.Size = new System.Drawing.Size(305, 675);
            this.SizeChanged += new System.EventHandler(this.qrCodeImg_SizeChanged);
            this.rightParentPanel.ResumeLayout(false);
            this.rightParentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeUpdateFrequencyBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightParentPanel;
        private System.Windows.Forms.PictureBox qrCodeImg;
        private System.Windows.Forms.TextBox logsTextBox;
        private System.Windows.Forms.TrackBar qrCodeUpdateFrequencyBar;
        private System.Windows.Forms.Label qRCodeUpdateFrequencyTxt;
        private System.Windows.Forms.Button qrcodeButton;
        private System.Windows.Forms.Label qrCodeCountDownTxt;
    }
}
