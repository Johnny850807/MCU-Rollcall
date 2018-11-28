using MCR.views;
using System;
using static MCR.views.QRCodeConsolePanel;

namespace MCR
{
    partial class MainForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.leftParentPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.rollcallTabPage = new System.Windows.Forms.TabPage();
            this.LeftFillPanel = new System.Windows.Forms.Panel();
            this.rollcallContainerPanel = new System.Windows.Forms.Panel();
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.skipAbsentorBtn = new System.Windows.Forms.Button();
            this.signNextAbsentorBtn = new System.Windows.Forms.Button();
            this.nextAbsentorNameTxt = new System.Windows.Forms.Label();
            this.nextAbsentorSpeakBtn = new System.Windows.Forms.Button();
            this.signingEventSpeakingChb = new System.Windows.Forms.CheckBox();
            this.studentsInfoPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.qRCodeConsolePanel = new MCR.views.QRCodeConsolePanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.使用者設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.教師帳密設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.偵聽Port設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iP設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.個人系統壓縮檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匯出個人資料壓縮檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.什麼是個人系統壓縮檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於我們ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.點名用特殊功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.未到者唱名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隨機唱名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部出席ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部取消出席ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自訂義用特殊功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.載入編輯課程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增學生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匯出點名紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.leftParentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.rollcallTabPage.SuspendLayout();
            this.LeftFillPanel.SuspendLayout();
            this.leftTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftParentPanel
            // 
            this.leftParentPanel.Controls.Add(this.tabControl);
            this.leftParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftParentPanel.Location = new System.Drawing.Point(0, 0);
            this.leftParentPanel.Name = "leftParentPanel";
            this.leftParentPanel.Size = new System.Drawing.Size(737, 652);
            this.leftParentPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.rollcallTabPage);
            this.tabControl.Controls.Add(this.studentsInfoPage);
            this.tabControl.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(737, 608);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // rollcallTabPage
            // 
            this.rollcallTabPage.Controls.Add(this.LeftFillPanel);
            this.rollcallTabPage.Controls.Add(this.leftTopPanel);
            this.rollcallTabPage.Location = new System.Drawing.Point(4, 25);
            this.rollcallTabPage.Name = "rollcallTabPage";
            this.rollcallTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.rollcallTabPage.Size = new System.Drawing.Size(729, 579);
            this.rollcallTabPage.TabIndex = 0;
            this.rollcallTabPage.Text = "點名";
            this.rollcallTabPage.UseVisualStyleBackColor = true;
            // 
            // LeftFillPanel
            // 
            this.LeftFillPanel.Controls.Add(this.rollcallContainerPanel);
            this.LeftFillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftFillPanel.Location = new System.Drawing.Point(2, 51);
            this.LeftFillPanel.Margin = new System.Windows.Forms.Padding(2);
            this.LeftFillPanel.Name = "LeftFillPanel";
            this.LeftFillPanel.Size = new System.Drawing.Size(725, 526);
            this.LeftFillPanel.TabIndex = 1;
            // 
            // rollcallContainerPanel
            // 
            this.rollcallContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollcallContainerPanel.AutoScroll = true;
            this.rollcallContainerPanel.Location = new System.Drawing.Point(1, 0);
            this.rollcallContainerPanel.Name = "rollcallContainerPanel";
            this.rollcallContainerPanel.Size = new System.Drawing.Size(778, 526);
            this.rollcallContainerPanel.TabIndex = 0;
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Controls.Add(this.skipAbsentorBtn);
            this.leftTopPanel.Controls.Add(this.signNextAbsentorBtn);
            this.leftTopPanel.Controls.Add(this.nextAbsentorNameTxt);
            this.leftTopPanel.Controls.Add(this.nextAbsentorSpeakBtn);
            this.leftTopPanel.Controls.Add(this.signingEventSpeakingChb);
            this.leftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTopPanel.Location = new System.Drawing.Point(2, 2);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(725, 49);
            this.leftTopPanel.TabIndex = 0;
            // 
            // skipAbsentorBtn
            // 
            this.skipAbsentorBtn.Location = new System.Drawing.Point(381, 12);
            this.skipAbsentorBtn.Name = "skipAbsentorBtn";
            this.skipAbsentorBtn.Size = new System.Drawing.Size(64, 23);
            this.skipAbsentorBtn.TabIndex = 11;
            this.skipAbsentorBtn.Text = "唱名( E )";
            this.skipAbsentorBtn.UseVisualStyleBackColor = true;
            this.skipAbsentorBtn.Click += new System.EventHandler(this.speakAbsentorNameBtn_Click);
            // 
            // signNextAbsentorBtn
            // 
            this.signNextAbsentorBtn.Location = new System.Drawing.Point(308, 12);
            this.signNextAbsentorBtn.Name = "signNextAbsentorBtn";
            this.signNextAbsentorBtn.Size = new System.Drawing.Size(67, 23);
            this.signNextAbsentorBtn.TabIndex = 10;
            this.signNextAbsentorBtn.Text = "簽到( W )";
            this.signNextAbsentorBtn.UseVisualStyleBackColor = true;
            this.signNextAbsentorBtn.Click += new System.EventHandler(this.signNextAbsentorBtn_Click);
            // 
            // nextAbsentorNameTxt
            // 
            this.nextAbsentorNameTxt.AutoSize = true;
            this.nextAbsentorNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextAbsentorNameTxt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nextAbsentorNameTxt.Location = new System.Drawing.Point(154, 12);
            this.nextAbsentorNameTxt.Name = "nextAbsentorNameTxt";
            this.nextAbsentorNameTxt.Size = new System.Drawing.Size(139, 22);
            this.nextAbsentorNameTxt.TabIndex = 9;
            this.nextAbsentorNameTxt.Text = "下一位缺席者名稱";
            // 
            // nextAbsentorSpeakBtn
            // 
            this.nextAbsentorSpeakBtn.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nextAbsentorSpeakBtn.Location = new System.Drawing.Point(6, 11);
            this.nextAbsentorSpeakBtn.Name = "nextAbsentorSpeakBtn";
            this.nextAbsentorSpeakBtn.Size = new System.Drawing.Size(131, 24);
            this.nextAbsentorSpeakBtn.TabIndex = 8;
            this.nextAbsentorSpeakBtn.Text = "下一位缺席者( Q )";
            this.nextAbsentorSpeakBtn.UseVisualStyleBackColor = true;
            this.nextAbsentorSpeakBtn.Click += new System.EventHandler(this.nextAbsentorSpeakBtn_Click);
            // 
            // signingEventSpeakingChb
            // 
            this.signingEventSpeakingChb.AutoSize = true;
            this.signingEventSpeakingChb.Location = new System.Drawing.Point(534, 11);
            this.signingEventSpeakingChb.Margin = new System.Windows.Forms.Padding(2);
            this.signingEventSpeakingChb.Name = "signingEventSpeakingChb";
            this.signingEventSpeakingChb.Size = new System.Drawing.Size(99, 20);
            this.signingEventSpeakingChb.TabIndex = 6;
            this.signingEventSpeakingChb.Text = "開啟簽到唱名";
            this.signingEventSpeakingChb.UseVisualStyleBackColor = true;
            // 
            // studentsInfoPage
            // 
            this.studentsInfoPage.BackColor = System.Drawing.Color.Transparent;
            this.studentsInfoPage.Location = new System.Drawing.Point(4, 25);
            this.studentsInfoPage.Margin = new System.Windows.Forms.Padding(2);
            this.studentsInfoPage.Name = "studentsInfoPage";
            this.studentsInfoPage.Padding = new System.Windows.Forms.Padding(2);
            this.studentsInfoPage.Size = new System.Drawing.Size(729, 579);
            this.studentsInfoPage.TabIndex = 1;
            this.studentsInfoPage.Text = "學生資訊";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftParentPanel);
            this.splitContainer1.Panel1MinSize = 700;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.splitContainer1.Panel2.Controls.Add(this.qRCodeConsolePanel);
            this.splitContainer1.Size = new System.Drawing.Size(1155, 652);
            this.splitContainer1.SplitterDistance = 737;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 4;
            // 
            // qRCodeConsolePanel
            // 
            this.qRCodeConsolePanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.qRCodeConsolePanel.countDown = 0;
            this.qRCodeConsolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qRCodeConsolePanel.Location = new System.Drawing.Point(0, 0);
            this.qRCodeConsolePanel.Name = "qRCodeConsolePanel";
            this.qRCodeConsolePanel.qRCodeButtonText = "運行點名伺服器";
            this.qRCodeConsolePanel.qrCodeImage = ((System.Drawing.Image)(resources.GetObject("qRCodeConsolePanel.qrCodeImage")));
            this.qRCodeConsolePanel.Size = new System.Drawing.Size(416, 652);
            this.qRCodeConsolePanel.TabIndex = 0;
            this.qRCodeConsolePanel.onQRCodeFrequenceTrackBarScrolled += new MCR.views.QRCodeConsolePanel.OnQRCodeFrequenceTrackBarScrolled(this.qRCodeConsolePanel_trackBarScrolled);
            this.qRCodeConsolePanel.onQRCodeButtonClick += new MCR.views.QRCodeConsolePanel.OnQRCodeButtonClick(this.qRCodeConsolePanel_QRCodeButtonClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用者設定ToolStripMenuItem,
            this.個人系統壓縮檔ToolStripMenuItem,
            this.關於ToolStripMenuItem,
            this.點名用特殊功能ToolStripMenuItem,
            this.自訂義用特殊功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 使用者設定ToolStripMenuItem
            // 
            this.使用者設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.教師帳密設定ToolStripMenuItem,
            this.偵聽Port設定ToolStripMenuItem,
            this.iP設定ToolStripMenuItem});
            this.使用者設定ToolStripMenuItem.Name = "使用者設定ToolStripMenuItem";
            this.使用者設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.使用者設定ToolStripMenuItem.Text = "設定";
            // 
            // 教師帳密設定ToolStripMenuItem
            // 
            this.教師帳密設定ToolStripMenuItem.Name = "教師帳密設定ToolStripMenuItem";
            this.教師帳密設定ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.教師帳密設定ToolStripMenuItem.Text = "教師帳密設定";
            this.教師帳密設定ToolStripMenuItem.Click += new System.EventHandler(this.教師帳密設定ToolStripMenuItem_Click);
            // 
            // 偵聽Port設定ToolStripMenuItem
            // 
            this.偵聽Port設定ToolStripMenuItem.Name = "偵聽Port設定ToolStripMenuItem";
            this.偵聽Port設定ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.偵聽Port設定ToolStripMenuItem.Text = "偵聽 Port 設定";
            this.偵聽Port設定ToolStripMenuItem.Click += new System.EventHandler(this.偵聽Port設定ToolStripMenuItem_Click);
            // 
            // iP設定ToolStripMenuItem
            // 
            this.iP設定ToolStripMenuItem.Name = "iP設定ToolStripMenuItem";
            this.iP設定ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.iP設定ToolStripMenuItem.Text = "IP設定";
            this.iP設定ToolStripMenuItem.Click += new System.EventHandler(this.iP設定ToolStripMenuItem_Click);
            // 
            // 個人系統壓縮檔ToolStripMenuItem
            // 
            this.個人系統壓縮檔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.匯出個人資料壓縮檔ToolStripMenuItem,
            this.什麼是個人系統壓縮檔ToolStripMenuItem});
            this.個人系統壓縮檔ToolStripMenuItem.Name = "個人系統壓縮檔ToolStripMenuItem";
            this.個人系統壓縮檔ToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.個人系統壓縮檔ToolStripMenuItem.Text = "個人系統壓縮檔";
            // 
            // 匯出個人資料壓縮檔ToolStripMenuItem
            // 
            this.匯出個人資料壓縮檔ToolStripMenuItem.Name = "匯出個人資料壓縮檔ToolStripMenuItem";
            this.匯出個人資料壓縮檔ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.匯出個人資料壓縮檔ToolStripMenuItem.Text = "匯出個人系統壓縮檔";
            this.匯出個人資料壓縮檔ToolStripMenuItem.Click += new System.EventHandler(this.匯出個人資料壓縮檔ToolStripMenuItem_Click);
            // 
            // 什麼是個人系統壓縮檔ToolStripMenuItem
            // 
            this.什麼是個人系統壓縮檔ToolStripMenuItem.Name = "什麼是個人系統壓縮檔ToolStripMenuItem";
            this.什麼是個人系統壓縮檔ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.什麼是個人系統壓縮檔ToolStripMenuItem.Text = "什麼是個人系統壓縮檔？";
            this.什麼是個人系統壓縮檔ToolStripMenuItem.Click += new System.EventHandler(this.什麼是個人系統壓縮檔ToolStripMenuItem_Click);
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於我們ToolStripMenuItem1});
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // 關於我們ToolStripMenuItem1
            // 
            this.關於我們ToolStripMenuItem1.Name = "關於我們ToolStripMenuItem1";
            this.關於我們ToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.關於我們ToolStripMenuItem1.Text = "關於 MCR";
            this.關於我們ToolStripMenuItem1.Click += new System.EventHandler(this.關於我們ToolStripMenuItem1_Click);
            // 
            // 點名用特殊功能ToolStripMenuItem
            // 
            this.點名用特殊功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.未到者唱名ToolStripMenuItem,
            this.隨機唱名ToolStripMenuItem,
            this.全部出席ToolStripMenuItem,
            this.全部取消出席ToolStripMenuItem});
            this.點名用特殊功能ToolStripMenuItem.Name = "點名用特殊功能ToolStripMenuItem";
            this.點名用特殊功能ToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.點名用特殊功能ToolStripMenuItem.Text = "點名用特殊功能";
            // 
            // 未到者唱名ToolStripMenuItem
            // 
            this.未到者唱名ToolStripMenuItem.Name = "未到者唱名ToolStripMenuItem";
            this.未到者唱名ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.未到者唱名ToolStripMenuItem.Text = "未到者唱名";
            this.未到者唱名ToolStripMenuItem.Click += new System.EventHandler(this.未到者唱名ToolStripMenuItem_Click);
            // 
            // 隨機唱名ToolStripMenuItem
            // 
            this.隨機唱名ToolStripMenuItem.Name = "隨機唱名ToolStripMenuItem";
            this.隨機唱名ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.隨機唱名ToolStripMenuItem.Text = "隨機唱名";
            this.隨機唱名ToolStripMenuItem.Click += new System.EventHandler(this.隨機唱名ToolStripMenuItem_Click);
            // 
            // 全部出席ToolStripMenuItem
            // 
            this.全部出席ToolStripMenuItem.Name = "全部出席ToolStripMenuItem";
            this.全部出席ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.全部出席ToolStripMenuItem.Text = "全部出席";
            this.全部出席ToolStripMenuItem.Click += new System.EventHandler(this.全部出席ToolStripMenuItem_Click);
            // 
            // 全部取消出席ToolStripMenuItem
            // 
            this.全部取消出席ToolStripMenuItem.Name = "全部取消出席ToolStripMenuItem";
            this.全部取消出席ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.全部取消出席ToolStripMenuItem.Text = "全部取消出席";
            this.全部取消出席ToolStripMenuItem.Click += new System.EventHandler(this.全部取消出席ToolStripMenuItem_Click);
            // 
            // 自訂義用特殊功能ToolStripMenuItem
            // 
            this.自訂義用特殊功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.載入編輯課程ToolStripMenuItem,
            this.新增學生ToolStripMenuItem,
            this.匯出點名紀錄ToolStripMenuItem});
            this.自訂義用特殊功能ToolStripMenuItem.Enabled = false;
            this.自訂義用特殊功能ToolStripMenuItem.Name = "自訂義用特殊功能ToolStripMenuItem";
            this.自訂義用特殊功能ToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.自訂義用特殊功能ToolStripMenuItem.Text = "自訂義用特殊功能";
            // 
            // 載入編輯課程ToolStripMenuItem
            // 
            this.載入編輯課程ToolStripMenuItem.Name = "載入編輯課程ToolStripMenuItem";
            this.載入編輯課程ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.載入編輯課程ToolStripMenuItem.Text = "載入/編輯課程";
            this.載入編輯課程ToolStripMenuItem.Click += new System.EventHandler(this.載入編輯課程ToolStripMenuItem_Click);
            // 
            // 新增學生ToolStripMenuItem
            // 
            this.新增學生ToolStripMenuItem.Name = "新增學生ToolStripMenuItem";
            this.新增學生ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.新增學生ToolStripMenuItem.Text = "新增學生";
            this.新增學生ToolStripMenuItem.Click += new System.EventHandler(this.新增學生ToolStripMenuItem_Click);
            // 
            // 匯出點名紀錄ToolStripMenuItem
            // 
            this.匯出點名紀錄ToolStripMenuItem.Name = "匯出點名紀錄ToolStripMenuItem";
            this.匯出點名紀錄ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.匯出點名紀錄ToolStripMenuItem.Text = "匯出點名紀錄(ctr+s)";
            this.匯出點名紀錄ToolStripMenuItem.Click += new System.EventHandler(this.匯出點名紀錄ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 676);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCR 高效率點名系統";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.leftParentPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.rollcallTabPage.ResumeLayout(false);
            this.LeftFillPanel.ResumeLayout(false);
            this.leftTopPanel.ResumeLayout(false);
            this.leftTopPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.Panel leftParentPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 使用者設定ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 教師帳密設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於我們ToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage rollcallTabPage;
        private System.Windows.Forms.Panel LeftFillPanel;
        private System.Windows.Forms.Panel rollcallContainerPanel;
        private System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.CheckBox signingEventSpeakingChb;
        private System.Windows.Forms.TabPage studentsInfoPage;
        private QRCodeConsolePanel qRCodeConsolePanel;
        private StudentsConsolePanel studentsConsolePanel;
        private System.Windows.Forms.ToolStripMenuItem 偵聽Port設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iP設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 個人系統壓縮檔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匯出個人資料壓縮檔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 什麼是個人系統壓縮檔ToolStripMenuItem;
        private System.Windows.Forms.Button nextAbsentorSpeakBtn;
        private System.Windows.Forms.Label nextAbsentorNameTxt;
        private System.Windows.Forms.Button signNextAbsentorBtn;
        private System.Windows.Forms.Button skipAbsentorBtn;
        private System.Windows.Forms.ToolStripMenuItem 點名用特殊功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 未到者唱名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隨機唱名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部出席ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部取消出席ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自訂義用特殊功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增學生ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 載入編輯課程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匯出點名紀錄ToolStripMenuItem;
    }
}

