using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Speech.Synthesis;
using MCR.views;
using MCR.models;
using MCR.adapters;
using MCR.utils;
using MCR.server;
using mshtml;
using System.Linq;
using System.Threading.Tasks;
using MCR.exceptions;
using System.Drawing;
using MCR.models.viewmodels;
using MCR.models.tools;

namespace MCR
{
    public partial class MainForm : BaseForm, RollcallView
    {
        private const string TAG = "MainForm";
        private const int TAB_ROLLCALL = 0;
        private const int TAB_STUDENTS_INFO = 1;
        private BaseRollcallConsolePanel rollcallConsolePanel;
        private RollcallServer server;
        private McrFactory mcrFactory;
        private NetStatesManager netStatesManager;
        private TTS absentStudentsSpeaker;
        private TTS nameSpeaker;

        private MainForm()
        {
            InitializeComponent();
            
        }

        public MainForm(McrFactory mcrFactory, BaseRollcallConsolePanel rollcallConsolePanel) : this()
        {
            this.mcrFactory = mcrFactory;
            this.netStatesManager = mcrFactory.getNetStatesManager();
            this.absentStudentsSpeaker = mcrFactory.createTTS();
            this.nameSpeaker = mcrFactory.createTTS();
            this.rollcallConsolePanel = rollcallConsolePanel;
            setupRollcallPanel(rollcallConsolePanel);
            setupStudentsConsolePage();
            if (rollcallConsolePanel.GetType() == typeof(RollcallUserDefinedSessionPanel))
                自訂義用特殊功能ToolStripMenuItem.Enabled = true;
        }

        private void setupRollcallPanel(BaseRollcallConsolePanel rollcallConsolePanel)
        {
            this.rollcallConsolePanel.rollcallSessionPrepared += this.onRollcallSessionPrepared;
            this.rollcallConsolePanel.leavingRollcallPage += this.onLeavingRollcallPage;
            UserControl rollcallPanelControl = (UserControl) this.rollcallConsolePanel;
            rollcallPanelControl.Dock = DockStyle.Fill;
            this.rollcallContainerPanel.Controls.Add(rollcallPanelControl);
        }


        private void onRollcallSessionPrepared()
        {
            addNewLog("點名頁面載入完畢。");
        }

        private void onLeavingRollcallPage()
        {
            addNewLog("已結束點名頁面。");
            stopServerAndResetStates();
        }

        private void setupStudentsConsolePage()
        {
            this.studentsConsolePanel = new StudentsConsolePanel(mcrFactory, 
                                                    rollcallConsolePanel, rollcallConsolePanel, 
                                                    this);

            this.studentsConsolePanel.addStudentInstanceListener(this.rollcallConsolePanel);
            this.studentsConsolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsInfoPage.Controls.Add(this.studentsConsolePanel);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NetUtils.turnOffFireWall();
            qRCodeConsolePanel.addNewLog("頁面載入完畢。");
            this.KeyPreview = true;
        }

        private void tabControl_Selected(object sender, EventArgs e)
        {
            //when the user refocus to the students info tab page
            //reload the sessions so as to get the latest states of students and sessions
            if (tabControl.SelectedIndex == TAB_STUDENTS_INFO)
                studentsConsolePanel.reloadAllStatesAndUpdate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            absentStudentsSpeaker.stopSpeaking();
        }
        
        public void qRCodeConsolePanel_QRCodeButtonClick()
        {
            if (alertIfSessionNotReady())
            {
                if (server == null || !server.isRunning())
                {
                    initAndRebootServer();
                    qRCodeConsolePanel.qRCodeButtonText = "關閉點名伺服器";
                }
                else
                    stopServerAndResetStates();
            }
        }   

        private void initAndRebootServer()
        {
            qRCodeConsolePanel.addNewLog("正在運行QR Code引擎...");
            if (server == null)
            {
                qRCodeConsolePanel.addNewLog("正在初始化伺服器...");
                server = new RollcallServer(rollcallConsolePanel.getCurrentSession(), mcrFactory.getNetStatesManager(),
                    mcrFactory.createMcrRepository(), qRCodeConsolePanel.qrCodeTrackBarValue);
                server.setRollcallView(this);
            }
            else
                server.stopServer();

            alertIfUsingPrivateIp();
            qRCodeConsolePanel.addNewLog("伺服器 IP 為: " + server.ip);
            qRCodeConsolePanel.addNewLog("正在載入學生資訊...");
            server.startRollcallServer();
            qRCodeConsolePanel.addNewLog("QR Code引擎已成功運行。");
            qRCodeConsolePanel.setShowQRCodeCountDown(true);
        }
        
        private void alertIfUsingPrivateIp()
        {
            if (NetUtils.isPrivateIp(server.ip))
                MessageBox.Show("目前您使用的Ip為區網Ip，\n請確認所有學生皆以連上區網。\n若您想要更換IP，請至[設定->IP設定]。");
        }

        public void stopServerAndResetStates()
        {
            server?.stopServer();
            qRCodeConsolePanel.qRCodeButtonText = "運行點名伺服器";
            qRCodeConsolePanel.qrCodeImage = Properties.Resources.mcu_logo;
            absentStudentsSpeaker.stopSpeaking();
            studentsConsolePanel.reloadAllStatesAndUpdate();
            qRCodeConsolePanel.setShowQRCodeCountDown(false);
            server = null;
        }

        private void qRCodeConsolePanel_trackBarScrolled(int value)
        {
            server?.setQRCodeUpdatedIntervalTime(value);
        }

        public void onStudentSignIn(Student student)
        {
            if (rollcallConsolePanel.isStudentValid(student))
            {
                rollcallConsolePanel.signStudent(student, true);
                addNewLog("學生 [" + student.name + "] 已簽到.");
                if (signingEventSpeakingChb.Checked)
                    Task.Factory.StartNew(()=> nameSpeaker.speak(student.name + "已到", 7));
                studentsConsolePanel.updateStudentState(student, RollcallStudent.State.SIGNED);
            }
            else
                addNewLog("學生 [" + student.name + "] 不合法，無法進行點名。");
        }

        public void onStudentBlocked(Student student)
        {
            qRCodeConsolePanel.addNewLog("學生 [" + student.name + "] 已被封鎖，切勿以身試法！");
            //TODO
        }

        public void onQRCodeCountDown(int time)
        {
            this.qRCodeConsolePanel.countDown = time;
        }

        public void onQRCodeTokenUpdated(string token)
        {
            qRCodeConsolePanel.updateQRCode(server.address, token);
        }
        
        private void startPlayingSpeechBtn_Click(object sender, EventArgs e)
        {
            if (absentStudentsSpeaker.isSpeaking())
                MessageBox.Show("請等候目前的語音撥放完畢！");
            else if (alertIfSessionNotReady())
                Task.Factory.StartNew(() => speakEveryAbsentorNamesViaTTS());
        }

        private void speakEveryAbsentorNamesViaTTS()
        {
            List<Student> unsignedStudents = (List<Student>)invokeOnMainThread(
                    () => rollcallConsolePanel.getUnsignedStudents());
            if (unsignedStudents.Count == 0)
            {
                absentStudentsSpeaker.speak("所有學生皆已出席！");
                addNewLog("所有學生皆已出席！");
            }
            else
            {
                absentStudentsSpeaker.speak("以下唸到學生微缺席，請盡速到前面來更正");
                absentStudentsSpeaker.speak(unsignedStudents.Select(u => u.name).ToList());
            }
        }
        
        public void onError(Exception err)
        {
            var msg = "發生問題: " + err.Message + "[" + err.StackTrace + "] 請通知開發人員。";
            MessageBox.Show(msg);
            addNewLog(msg);
        }
        
        private void signAllStudentsBtn_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady()) 
                rollcallConsolePanel.signAllStudents(true);
        }

        private void unsignAllStudentsBtn_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady())
                rollcallConsolePanel.signAllStudents(false);
        }

        private Student nextAbsentor;
        private List<Student> skippedStudents = new List<Student>();
        private void nextAbsentorSpeakBtn_Click(object sender, EventArgs e)
        {

            if (alertIfSessionNotReady())
            {
                var students = rollcallConsolePanel.getUnsignedStudents();
                if (students.Count != 0)
                {
                    //remove all the students those are already spoken
                    students.RemoveAll(s => skippedStudents.Contains(s));
                    if (students.Count == 0) //then check if we reach the tail of all students
                    {
                        DialogResult dialogResult = MessageBox.Show("重新", "所有缺席的學生已經循環完畢，是否重新再循環一次？", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            skippedStudents.Clear();
                            students = rollcallConsolePanel.getUnsignedStudents();
                        }
                        else
                            return;
                    }
                    nextAbsentor = students.First();
                    skippedStudents.Add(nextAbsentor);
                    nextAbsentorNameTxt.Text = nextAbsentor.name;
                    nextAbsentorNameTxt.ForeColor = Color.Blue;
                    Task.Factory.StartNew(() => nameSpeaker.speak(nextAbsentor.name));
                }
                else
                    Task.Factory.StartNew(() => absentStudentsSpeaker.speak("所有學生皆已出席"));
            }
        }

        private void speakAbsentorNameBtn_Click(object sender, EventArgs e)
        {
            if (nextAbsentor != null)
                Task.Factory.StartNew(() => nameSpeaker.speak(nextAbsentor.name));
        }

        private void signNextAbsentorBtn_Click(object sender, EventArgs e)
        {
            if (nextAbsentor != null)
            {
                rollcallConsolePanel.signStudent(nextAbsentor, true);
                nextAbsentorNameTxt.Text = "---";
                nextAbsentorNameTxt.ForeColor = Color.Black;
            }
            else
                Task.Factory.StartNew(() => absentStudentsSpeaker.speak("所有學生皆已出席"));
        }

        private void randomNameSpeakBtn_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady())
            {
                var students = rollcallConsolePanel.getCurrentSession().students;
                if (students.Count == 0)
                    MessageBox.Show("該課程沒有學生！");
                else
                {
                    var studentNames = students.Select(s => s.name).ToArray();
                    int randIndex = new Random().Next(0, studentNames.Length - 1);
                    nameSpeaker.speak(studentNames[randIndex]);
                }
            }
        }

        private bool alertIfSessionNotReady()
        {
            var isSessionLoaded = rollcallConsolePanel.isRollcallSessionStarted();
            if (!isSessionLoaded)
            {
                var msg = rollcallConsolePanel is RollcallWebPanel ? "請先至點名頁面！" : "請先載入自定義課程唷！";
                MessageBox.Show(msg);
            }
            return isSessionLoaded;
        }

        private void 教師帳密設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AccountSettingDialog accountSessingDialog = new AccountSettingDialog())
            {
                if (accountSessingDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("帳密設置完成！");
                    UserConfig userConfig = UserConfig.getInstance();
                    userConfig.setAccount(accountSessingDialog.account);
                    userConfig.setPassword(accountSessingDialog.password);
                    qRCodeConsolePanel.addNewLog("帳密已以加密方式儲存至本機:)。");
                    if (rollcallConsolePanel is RollcallWebPanel)
                        (rollcallConsolePanel as RollcallWebPanel).loadAccountAndPassword();
                }
            }
        }

        private void 關於我們ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (DeveloperInfoDialog dialog = new DeveloperInfoDialog())
                dialog.ShowDialog();
        }
        
        public void addNewLog(string log, bool newLine = true)
        {
            qRCodeConsolePanel.addNewLog(log, newLine);
        }

        private void 偵聽Port設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var serverSettingDialog = new ServerSettingDialog(netStatesManager))
                serverSettingDialog.ShowDialog();
        }

        private void iP設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contextMenuHeader = new ContextMenuStrip();
            contextMenuHeader.Font = new Font("微軟正黑體", 15, FontStyle.Bold);
            string[] ips = NetUtils.getIps();
            foreach (var ip in ips)
            {
                var item = contextMenuHeader.Items.Add(ip);
                item.Click += (s, eg) =>
                {
                    if (server != null)
                        netStatesManager.setIp(ip);
                    addNewLog("伺服器 IP 已改變為： " + ip + ", 請重啟伺服器。");
                };
            }
            contextMenuHeader.Show(Cursor.Position);
        }

        private void 匯出個人資料壓縮檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var outputPath = FileUtils.createDirectoryIfNotExists("output");
            var defaultFileName = "個人系統壓縮檔" + DateTime.Now.ToString("yyyyMMddHHMMss") + ".exe";
            var chosenPath = DialogUtils.createAndShowDialogForChoosingFilePath(outputPath, defaultFileName);
            if (chosenPath != null)
            {
                using (var dialog = new ExportingMcrInstallerDialog(chosenPath))
                {
                    McrInstallerFactory.execute(() => onMcrInstallerExecutionFinished(dialog),
                                                () => onMcrInstallerExecutionError(dialog),
                                                chosenPath);
                    dialog.ShowDialog();
                    addNewLog("個人系統壓縮檔案正在生成...");
                }
            }
        }

        private void onMcrInstallerExecutionFinished(ExportingMcrInstallerDialog dialog)
        {
            invokeOnMainThread(dialog.Close);
            MessageBox.Show("個人系統壓縮檔產生完畢！(請勿更改此壓縮檔檔名！)");
        }

        private void onMcrInstallerExecutionError(ExportingMcrInstallerDialog dialog)
        {
            invokeOnMainThread(dialog.Close);
            MessageBox.Show("個人系統壓縮檔失敗，請再嘗試一次！");
        }

        private void 什麼是個人系統壓縮檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var whatIsMCUInstallerDialog = new WhatIsMCUInstallerDialog())
                whatIsMCUInstallerDialog.ShowDialog();
        }

        private void 未到者唱名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (absentStudentsSpeaker.isSpeaking())
                MessageBox.Show("請等候目前的語音撥放完畢！");
            else if (alertIfSessionNotReady())
                Task.Factory.StartNew(() => speakEveryAbsentorNamesViaTTS());
        }

        private void 隨機唱名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady())
            {
                var students = rollcallConsolePanel.getCurrentSession().students;
                if (students.Count == 0)
                    MessageBox.Show("該課程沒有學生！");
                else
                {
                    var studentNames = students.Select(s => s.name).ToArray();
                    int randIndex = new Random().Next(0, studentNames.Length - 1);
                    nameSpeaker.speak(studentNames[randIndex]);
                }
            }

        }

        private void 全部出席ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady())
                rollcallConsolePanel.signAllStudents(true);
        }

        private void 全部取消出席ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alertIfSessionNotReady())
                rollcallConsolePanel.signAllStudents(false);
        }
        

        private void 新增學生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rollcallConsolePanel.getCurrentSession() == null)
                MessageBox.Show("請先載入課程");
            else
            {
                using (var addStudentDialog = new AddStudentDialog())
                {
                    if (addStudentDialog.ShowDialog() == DialogResult.OK)
                    {
                        var student = addStudentDialog.student;
                        rollcallConsolePanel.createStudent(student);

                    }
                }
            }
        }

        private void 載入編輯課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SessionManagementDialog sessionManagementDialog = new SessionManagementDialog(mcrFactory))
            {
                if (sessionManagementDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sessionManagementDialog.chosenSession == null)
                        MessageBox.Show("沒選到課程");
                    else
                    {
                        rollcallConsolePanel.onSessionCreated(sessionManagementDialog.chosenSession);
                    }
                }
            }
        }

        private void 匯出點名紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rollcallConsolePanel.onRecordExport();
        }
        
   
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                nextAbsentorSpeakBtn.PerformClick();
            }
            if(e.KeyCode == Keys.W)
            {
                signNextAbsentorBtn.PerformClick();
            }
            if(e.KeyCode == Keys.E)
            {
                skipAbsentorBtn.PerformClick();
            }
            if (自訂義用特殊功能ToolStripMenuItem.Enabled == true && e.Control == true && e.KeyCode == Keys.S )
            {
                匯出點名紀錄ToolStripMenuItem.PerformClick();
            }

        }
    }
}


