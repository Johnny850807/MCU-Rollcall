namespace MCR.views
{
    partial class RollcallWebPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RollcallWebPanel));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.goHomeBtn = new System.Windows.Forms.Button();
            this.webbrowserNextPageBtn = new System.Windows.Forms.Button();
            this.webbrowserPreviousPageBtn = new System.Windows.Forms.Button();
            this.setShowingAllPictureChb = new System.Windows.Forms.CheckBox();
            this.leftTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 46);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1431, 798);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.Url = new System.Uri("http://www2.mcu.edu.tw", System.UriKind.Absolute);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Controls.Add(this.goHomeBtn);
            this.leftTopPanel.Controls.Add(this.webbrowserNextPageBtn);
            this.leftTopPanel.Controls.Add(this.webbrowserPreviousPageBtn);
            this.leftTopPanel.Controls.Add(this.setShowingAllPictureChb);
            this.leftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTopPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(1431, 46);
            this.leftTopPanel.TabIndex = 2;
            // 
            // goHomeBtn
            // 
            this.goHomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("goHomeBtn.Image")));
            this.goHomeBtn.Location = new System.Drawing.Point(109, 12);
            this.goHomeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goHomeBtn.Name = "goHomeBtn";
            this.goHomeBtn.Size = new System.Drawing.Size(47, 29);
            this.goHomeBtn.TabIndex = 5;
            this.goHomeBtn.UseVisualStyleBackColor = true;
            this.goHomeBtn.Click += new System.EventHandler(this.goHomeBtn_Click);
            // 
            // webbrowserNextPageBtn
            // 
            this.webbrowserNextPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("webbrowserNextPageBtn.Image")));
            this.webbrowserNextPageBtn.Location = new System.Drawing.Point(57, 15);
            this.webbrowserNextPageBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webbrowserNextPageBtn.Name = "webbrowserNextPageBtn";
            this.webbrowserNextPageBtn.Size = new System.Drawing.Size(33, 22);
            this.webbrowserNextPageBtn.TabIndex = 4;
            this.webbrowserNextPageBtn.UseVisualStyleBackColor = true;
            this.webbrowserNextPageBtn.Click += new System.EventHandler(this.webbrowserNextPageBtn_Click);
            // 
            // webbrowserPreviousPageBtn
            // 
            this.webbrowserPreviousPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("webbrowserPreviousPageBtn.Image")));
            this.webbrowserPreviousPageBtn.Location = new System.Drawing.Point(15, 15);
            this.webbrowserPreviousPageBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webbrowserPreviousPageBtn.Name = "webbrowserPreviousPageBtn";
            this.webbrowserPreviousPageBtn.Size = new System.Drawing.Size(33, 22);
            this.webbrowserPreviousPageBtn.TabIndex = 3;
            this.webbrowserPreviousPageBtn.UseVisualStyleBackColor = true;
            this.webbrowserPreviousPageBtn.Click += new System.EventHandler(this.webbrowserPreviousPageBtn_Click);
            // 
            // setShowingAllPictureChb
            // 
            this.setShowingAllPictureChb.Checked = true;
            this.setShowingAllPictureChb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setShowingAllPictureChb.Location = new System.Drawing.Point(180, 16);
            this.setShowingAllPictureChb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setShowingAllPictureChb.Name = "setShowingAllPictureChb";
            this.setShowingAllPictureChb.Size = new System.Drawing.Size(132, 24);
            this.setShowingAllPictureChb.TabIndex = 0;
            this.setShowingAllPictureChb.Text = "顯示學生圖片";
            this.setShowingAllPictureChb.CheckedChanged += new System.EventHandler(this.setShowingAllPictureChb_CheckedChanged);
            // 
            // RollcallWebPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.leftTopPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RollcallWebPanel";
            this.Size = new System.Drawing.Size(1431, 844);
            this.leftTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.CheckBox setShowingAllPictureChb;
        private System.Windows.Forms.Button goHomeBtn;
        private System.Windows.Forms.Button webbrowserNextPageBtn;
        private System.Windows.Forms.Button webbrowserPreviousPageBtn;
    }
}
