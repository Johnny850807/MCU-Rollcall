using System;
using System.Windows.Forms;
using MCR.server;
using System.Drawing;

namespace MCR.views
{
    public partial class QRCodeConsolePanel : BaseUserControl, LoggerView
    {
        private const int COUNTDOWN_TXT_HEIGHT = 40;
        private Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
        public int qrCodeTrackBarValue { get { return qrCodeUpdateFrequencyBar.Value; } }

        public delegate void OnQRCodeFrequenceTrackBarScrolled(int value);
        public event OnQRCodeFrequenceTrackBarScrolled onQRCodeFrequenceTrackBarScrolled;
        public delegate void OnQRCodeButtonClick();
        public event OnQRCodeButtonClick onQRCodeButtonClick;

        public QRCodeConsolePanel()
        {
            InitializeComponent();
            setShowQRCodeCountDown(false);
        }

        private void qrcodeBtn_Click(object sender, EventArgs e)
        {
            onQRCodeButtonClick?.Invoke();
        }

        private int _countDown;
        public int countDown
        {
            get
            {
                return _countDown;
            }
            set
            {
                _countDown = value;
                qrCodeCountDownTxt.Text = String.Format("---- 更新倒數 {0} !----", _countDown);
            }
        }

        public void setShowQRCodeCountDown(bool show)
        {
            qrCodeCountDownTxt.Height = show ? COUNTDOWN_TXT_HEIGHT : 0;
        }

        public string qRCodeButtonText
        {
            get { return qrcodeButton.Text; }
            set { qrcodeButton.Text = value; }
        }

        public Image qrCodeImage
        {
            get { return qrCodeImg.Image; }
            set { this.qrCodeImg.Image = value; }
        }

        private void qrCodeUpdateFrequencyBar_Scroll(object sender, EventArgs e)
        {
            var timeInterval = ((TrackBar)sender).Value; 
            this.qRCodeUpdateFrequencyTxt.Text = "QR Code 更新頻率(" + timeInterval + "秒)";
            onQRCodeFrequenceTrackBarScrolled?.Invoke(timeInterval);
        }

        private void qrCodeImg_SizeChanged(object sender, EventArgs e)
        {
            remainQRCodeImageSquareAndCenterAligned();
        }

        private void remainQRCodeImageSquareAndCenterAligned()
        {
            /* because the location point of the rightParentPanel starts from
             * qrCodeCountDownTxt, however qrCodeImg is inside the rightParentPanel
             * and below qRCodeUpdateFrequencyTxt, qrCodeUpdateFrequencyBar and
             * qrCodeCountDownTxt, so
             * its start Y should be offset from them.
            */
            int startY = qRCodeUpdateFrequencyTxt.Height
                            + qrCodeCountDownTxt.Height
                            + qrCodeUpdateFrequencyBar.Height;
            int qrPanelHeight = rightParentPanel.Height 
                                - startY 
                                - logsTextBox.Height - 5 /*padding*/;
            int qrPanelWidth = rightParentPanel.Width - 10 /*padding*/;

            var point = qrCodeImg.Location;
            if (qrPanelWidth > qrPanelHeight)  //remaining square
                this.qrCodeImg.Width = this.qrCodeImg.Height = qrPanelHeight;
            else if (qrPanelHeight > qrPanelWidth)
                this.qrCodeImg.Height = this.qrCodeImg.Width = qrPanelWidth;

            point.X = qrPanelWidth / 2 - this.qrCodeImg.Width / 2;
            point.Y = startY + qrPanelHeight / 2 - this.qrCodeImg.Height / 2 + qrCodeImg.Padding.Top;

            this.qrCodeImg.Location = point;
        }

        public void updateQRCode(string address, string token)
        {
            string urlRequest = address + "Sign/" +
                SignController.APIs.API_SIGN_IN + "?" +
                SignController.Keys.QRCODE_TOKEN + "=" + token;
            addNewLog("QRCode 更新 [" + token + "]");
            qrCodeImg.Image = qrcode.Draw(urlRequest, 50);
        }

        public void addNewLog(string log, bool newLine = true)
        {
            invokeOnMainThread(() =>
            {
                logsTextBox.Text += log + (newLine ? Environment.NewLine : "");
                logsTextBox.SelectionStart = logsTextBox.TextLength;  //scroll to bottom
                logsTextBox.ScrollToCaret();
            }
            );
        }
        
    }
}
