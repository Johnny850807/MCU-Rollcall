using MCR.models;
using MCR.models.repositories;
using MCR.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCR.utils;
using System.Text;
using System.Net;
using System.Timers;
using System.IO;

namespace MCR.server
{
    /// <summary> Author: Waterball
    /// The main server listening to HTTP websocket of some specific ports, fetching the request, 
    /// and sending it to the proper controller.
    /// 
    /// The rollcall server is binded to a Session
    /// 
    /// It also manages the lifecycle of QR Code token, which used to validate a
    /// Sign in request. 
    /// </summary>
    public class RollcallServer
    {
        private const string TAG = "RollcallServer";
        private const int QRCODE_TOKEN_LENGTH = 30;
        private Dictionary<string, Func<HttpListenerContext, RollCallController>> controllerFactories = new Dictionary<string, Func<HttpListenerContext, RollCallController>>();
        private bool running = false;
        private NetStatesManager netStatesQuerier;
        public string ip { get { return netStatesQuerier.getIp(); } }
        public int port { get { return netStatesQuerier.getPort(); } }
        public string address{ get {return "http://" + ip + ":" + port + "/";} }
        private HttpListener httpListener;
        private McrRepository mcrRepository;
        private RollcallView rollcallView;
        public Session session { get; set; }  //the holding session.
        private Timer countdownTimer;
        private int qrCodeUpdatedInterval;
        private int countdownNumber;
        private List<string> qrCodeTokens;
        private string qrCodeToken = null;  //qrCode token used to identify the valid QRCode instance.
        private string preQRCodeToken = null;

        static RollcallServer()
        {
            try
            {

                ResourceController.prepareResources();
            } catch (DirectoryNotFoundException err)
            {
                Console.WriteLine(err.StackTrace);
                throw err;
            }
         
        }

        public RollcallServer(Session session, NetStatesManager netStatesQuerier, 
                                        McrRepository mcrRepository, int qrCodeUpdatedInterval)
        {
            this.qrCodeTokens = new List<string>();
            this.mcrRepository = mcrRepository;
            this.session = session;
            this.netStatesQuerier = netStatesQuerier;
            this.countdownNumber = this.qrCodeUpdatedInterval = qrCodeUpdatedInterval;
            this.countdownTimer = new Timer(1000);
            this.countdownTimer.Elapsed += (sender, e) => onNextCountDown();

            Log.d(TAG, "Server created for a session (" + session + "), repository's type: " + mcrRepository.GetType());
            setupControllerFactoriesDict();

        }

        private void onNextCountDown()
        {
            bool expired = countdownNumber == 0;
            countdownNumber = expired ? qrCodeUpdatedInterval : countdownNumber - 1;

            rollcallView.invokeOnMainThread(()=> rollcallView.onQRCodeCountDown(countdownNumber));

             if (expired)
                updatedQRCodeTokenAndNotifyView();
        }


        /// <summary>
        /// In this method, all controller factories should be set with its key 
        /// used in the request's url pattern: {address:port}/{controllerName}/{api}, 
        /// where controllerName is the key.
        /// </summary>
        private void setupControllerFactoriesDict()
        {
            controllerFactories["Sign"] = (client) => new SignController(mcrRepository, 
                                                                        client, this, session);

            controllerFactories["Resources"] = (client) => new ResourceController(client, this);

        }

        public void setRollcallView(RollcallView rollcallView)
        {
            this.rollcallView = rollcallView;
        }

        public void signStudent(Student student)
        {
            rollcallView.invokeOnMainThread(() => rollcallView.onStudentSignIn(student));
        }

        public void blockStudent(Student student)
        {
            rollcallView.invokeOnMainThread(() =>
            {
                //TODO
            });
        }

        public void startRollcallServer()
        {
            if (rollcallView == null) throw new Exception("Rollcall view should be set before server started.");
            logAndShowMessage("伺服器正在啟動...");
            Task.Factory.StartNew(() =>
            {
                logAndShowMessage("正在設置 Http偵聽器...");
                enableRollcallServerPort();
                removeAllExpiredStudents();
                updatedQRCodeTokenAndNotifyView();
                countdownTimer.Start();
                initHttpListenerAndRunServer();
            }
            );
        }

        private void removeAllExpiredStudents()
        {
            logAndShowMessage("正在刪除過期的學生資料...", false);
            var expiredStudents = mcrRepository.getStudents().Where(s => s.expired());
            Parallel.ForEach(expiredStudents, s => mcrRepository.removeStudent(s.id));
            logAndShowMessage("[已刪除 " + expiredStudents.Count() + " 筆。]");
        }

        private void enableRollcallServerPort()
        {
            NetUtils.enableRollcallServerPort(ip, port);
            logAndShowMessage("伺服器埠(" + port + ")偵聽已開啟。");
        }

        private void initHttpListenerAndRunServer()
        {
            running = true;
            httpListener = new HttpListener();
            httpListener.Prefixes.Add(address);
            httpListener.Start();
            try
            {
                loopingListeningHttpRequest(httpListener);
            }
            catch(Exception err){Log.err(TAG, "HTTP ERROR.", err);}
            finally
            { 
                logAndShowMessage("伺服器已關閉。");
            }
        }

        private void loopingListeningHttpRequest(HttpListener httpListener)
        {
            while (running)
            {
                HttpListenerContext context = httpListener.GetContext();
                Task.Factory.StartNew(() => parseAndHandleNextClientRequest(context));
            }
        }

        private void parseAndHandleNextClientRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            try
            {
                string controllerName = request.Url.Segments[1].TrimEnd('/');
                var controller = getController(context, controllerName);
                controller.handleRequest();
            }
            catch (Exception err)
            {
                Log.err(TAG, "Error occurs while handling a request.", err);
            }
            finally{response.Close();}
        }

        public RollCallController getController(HttpListenerContext client, string controllerName)
        {
            Log.d(TAG, "Controller name splitted get: " + controllerName);
            var factory = controllerFactories["Resources"];  //DEFAULT
            if (controllerFactories.ContainsKey(controllerName))
                factory = controllerFactories[controllerName];
            var controller = factory.Invoke(client);
            Log.d(TAG, "Controller got: " + controller.GetType());
            return controller;
        }
        
        public bool isRunning()
        {
            return running;
        }

        public void stopServer()
        {
            logAndShowMessage("正在關閉伺服器...");
            this.running = false;
            httpListener.Abort();
            countdownTimer.Stop();
            logAndShowMessage("伺服器已停止運作。");
        }

        public void setQRCodeUpdatedIntervalTime(int time)
        {
            this.countdownNumber = this.qrCodeUpdatedInterval = time;
        }

        public string getQRCodeToken()
        {
            return qrCodeToken;
        }
        public string getPreQRCodeToken()
        {
            return qrCodeTokens[1];
        }
        
        private void updatedQRCodeTokenAndNotifyView()
        {
            var token = getNextQRCodeToken();
            rollcallView.invokeOnMainThread(() => rollcallView.onQRCodeTokenUpdated(token));
        }

        public string getNextQRCodeToken() {
            Random rnd = new Random();
            StringBuilder tokenBuilder = new StringBuilder();
            for (int i = 0; i < QRCODE_TOKEN_LENGTH; i++)
            {
                bool upperCase = rnd.Next(0, 2) == 1;
                tokenBuilder.Append(upperCase ? (char)rnd.Next(65, 91) : 
                                                (char)rnd.Next(97, 123));
            }
            if(qrCodeTokens.Count() < 1)
            {
                qrCodeTokens.Add(tokenBuilder.ToString());
                qrCodeTokens.Add(preQRCodeToken);
            }
            else
            {
                qrCodeTokens[1] = qrCodeTokens[0];
                qrCodeTokens[0] = tokenBuilder.ToString();
            }
            return this.qrCodeToken = tokenBuilder.ToString();
        }

        private void logAndShowMessage(string msg, bool newLineInTextBox = true)
        {
            Log.d(TAG, msg);
            rollcallView.addNewLog(msg, newLineInTextBox);
        }
    }
}
