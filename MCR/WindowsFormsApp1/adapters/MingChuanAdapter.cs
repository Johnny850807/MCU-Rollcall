using System;
using System.Collections.Generic;
using System.Linq;
using MCR.models;
using mshtml;
using MCR.utils;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MCR.models.viewmodels;
using MCR.views;

namespace MCR.adapters
{
    /// <summary>
    /// The adapter of the c# web browser with additional methods dealing with Rollcall functions.
    /// We use a very 'heavy' way to update from each request due to the Ming Chuan website sucking IFrame mechanism!
    /// So whenever the website changed into any new architecture, 
    /// all of us have to come back and make amend of all of the fucking html logics!
    /// 
    /// HERO of dealing with IFrame elements:
    /// https://dotblogs.com.tw/rainmaker/2015/09/19/153380
    /// </summary>
    public class MingChuanWebAdapter : RollcallWebBrowserAdapter
    {
        private string TAG = "MingChuanWebAdapter";
        private const int TOP_FRAME = 0;
        private const int LEFT_FRAME = 1;
        private const int ROLLCALL_FRAME = 2;
        private WebBrowser webBrowser;
        private NetStatesManager netStatesManager;

        /// <summary>
        /// Regex validating that only: (1) input (2) img element can be inside 
        /// the student td element. 
        /// If it's an img element then validate if its image source from
        /// (1) imgur (2) www.mcu.edu.tw 
        /// </summary>
        private const string REGEX_HTML_IS_STUDENT_TD = 
            "^(<IMG\\s+(src=\\\"https://(www.mcu.edu.tw/student/|i.imgur.com/)){1}|<INPUT)";

        public MingChuanWebAdapter(WebBrowser webBrowser, NetStatesManager ipQuerier)
        {
            this.webBrowser = webBrowser;
            this.netStatesManager = ipQuerier;
        }
        

        public RollcallStudent.State getStudentState(Student student)
        {
            if (!isRollcallSessionStarted())
                return RollcallStudent.State.NONE;
            if (isSigned(student))
                return RollcallStudent.State.SIGNED;
            return RollcallStudent.State.UNSIGNED;
        }
        
        public bool isStudentValid(Student student)
        {
            return student.isValid() && containsStudent(student);
        }

        public bool containsStudent(Student student)
        {
            return getCurrentStudents().Contains(student);
        }

        public bool isSigned(Student student)
        {
            return getSignedStudents().Count(s => s.studentId == student.studentId) != 0;
        }

        public List<Student> getSignedStudents()
        {
            return getRollcallStudents().Where(ss => ss.isSigned())
                .Select(ss => ss.getStudent()).ToList();
        }

        public List<Student> getUnsignedStudents()
        {
            return getRollcallStudents().Where(ss => !ss.isSigned())
                .Select(ss => ss.getStudent()).ToList();
        }

        public List<Student> getCurrentStudents()
        {
            return getRollcallStudents().Select(ss => ss.getStudent()).ToList();
        }

        public List<RollcallStudent> getRollcallStudents()
        {
            List<RollcallStudent> rollcallStudents = new List<RollcallStudent>();
            var rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            var innerT = rollpageFrame.documentElement.outerHTML;
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(innerT);

            var studentsTable = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='ctl00_ContentPlaceHolder1_ChkLStno']");

            try
            {
                foreach (var tdElm in studentsTable.SelectNodes(".//td"))
                {
                    var inputElm = tdElm.SelectSingleNode("./input");
                    var labelElm = tdElm.SelectSingleNode("./label");
                    if (labelElm == null || inputElm == null)
                        continue;
                    // Only if the input checkbox is checked, it has an attribute CHECKED='' 
                    // with an empty string value. So if we don't get the default value 'NO', 
                    // then it means the checkbox is checked, indicating the student is absent (not signed).
                    var isChecked = inputElm.GetAttributeValue("CHECKED", "NO") != "NO";
                    var student = new Student()
                    {
                        ip = netStatesManager.getIp(),
                        studentId = labelElm.InnerHtml.Substring(0, 8),
                        name = labelElm.InnerHtml.Substring(12, 3).Replace(" ", "")
                    };
                    rollcallStudents.Add(RollcallStudent.create(student, !isChecked));
                }
                return rollcallStudents;
            }
            catch(Exception err)
            {
                Log.err(TAG, "ERROR occurs while loading rollcall student. ", err);
                throw err;
            }
        }

        public void signStudent(Student student, bool signed)
        {
            IHTMLDocument2 htmlDoc = (IHTMLDocument2)webBrowser.Document.DomDocument;
            IHTMLDocument3 rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            var inputElms = rollpageFrame.getElementsByTagName("td")
                .OfType<IHTMLElement>().ToList();
            foreach (var elm in inputElms)
            {
                var html = elm.innerHTML == null ? null : elm.innerHTML.Trim();
                if (html != null && Regex.IsMatch(html, REGEX_HTML_IS_STUDENT_TD)
                        && html.Contains(student.studentId))
                {
                    if (signed)
                        elm.innerHTML = elm.innerHTML.Replace("CHECKED", "");
                    else
                        elm.setAttribute("checked", "checked");
                    break;
                }
            }
        }

        public bool isUnderRollcallPage()
        {
            IHTMLDocument2 htmlDoc = (IHTMLDocument2)webBrowser.Document.DomDocument;
            if (htmlDoc.frames.length <= ROLLCALL_FRAME)
                return false;
            IHTMLDocument3 rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            bool pageContainsKeyWord = rollpageFrame.documentElement.innerHTML.Contains("請點選缺席學生之座位");
            IHTMLElement studentsTable = rollpageFrame.getElementById("ctl00_ContentPlaceHolder1_ChkLStno");

            return studentsTable != null && pageContainsKeyWord;
        }

        public bool isRollcallSessionStarted()
        {
            IHTMLDocument2 htmlDoc = (IHTMLDocument2)webBrowser.Document.DomDocument;
            if (htmlDoc.frames.length <= ROLLCALL_FRAME)
                return false;
            IHTMLDocument3 rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            IHTMLElement studentsTable = rollpageFrame.getElementById("ctl00_ContentPlaceHolder1_ChkLStno");

            return studentsTable != null;
        }

        public Session getCurrentSession()
        {
            var rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            var courseSpan = rollpageFrame.getElementById("ctl00_ContentPlaceHolder1_LblClsCnm");
            Session session = new Session() { sessionType = Session.SessionType.COURSE };
            if (courseSpan != null)
            {
                var subject = "";
                var html = courseSpan.innerHTML;
                string[] split = html.Split('/');
                subject = split[1];
                session.subjectNumber = subject.Substring(0, 5);
                session.name = subject.Substring(5);
                session.students = new HashSet<Student>(getCurrentStudents());
                return session;
            }

            throw new Exception("The session's course span element not found.");
        }

        public void setupRollcallPage(bool showPictures)
        {
            IHTMLDocument3 rollpageFrame = parseFrameDocument(ROLLCALL_FRAME);
            signAllStudents(false);
            setShowingAllStudentPictures(showPictures);
        }

        public void signAllStudents(bool sign)
        {
            var inputEles = parseElementsFromRollcallFrame("input");
            foreach (var ele in inputEles)
            {
                if (ele.getAttribute("type") as string == "checkbox")
                    ele.setAttribute("checked", sign ? "" : "checked");
            }
        }
        
        public void setShowingAllStudentPictures(bool show)
        {
            Dictionary<string, string> imgsMatching = UserConfig.getInstance().getImageMatcingDict();
            var tdElms = parseElementsFromRollcallFrame("td");
            foreach (var elm in tdElms)
            {
                var prefix = show ? "<INPUT" : "<IMG";
                var html = elm.innerHTML == null ? null : elm.innerHTML.Trim();
                if (html != null && Regex.IsMatch(html, REGEX_HTML_IS_STUDENT_TD))
                {
                    //e.g. <input id="ctl00_ContentPlaceHolder1_ChkLStno_1" type="checkbox" name="ctl00$ContentPlaceHolder1$ChkLStno$1"><label for="ctl00_ContentPlaceHolder1_ChkLStno_1">03360014<br>陳培瑋</label>
                    var splitFirst = html.Split(new string[] { "<BR>" }, StringSplitOptions.None)[0];
                    var studentId = splitFirst.Substring(splitFirst.Length - 8, 8);
                    var ePortFolioProfileImgUrl = MingChuanUtils.getEPortfolioProfileImageUrl(studentId);
                    if (show)
                    {
                        var img = HtmlTagUtils.imageElement(ePortFolioProfileImgUrl, "113px", "82px") + HtmlTagUtils.br();
                        if (imgsMatching.ContainsKey(studentId))
                            img = HtmlTagUtils.imageElement(imgsMatching[studentId], "113px", "82px") + HtmlTagUtils.br();
                        elm.innerHTML = img + elm.innerHTML;
                    }
                    else  //strip off the <IMG> tag
                        elm.innerHTML = html.Substring(elm.innerHTML.IndexOf("<INPUT")); 
                }
            }
        }

        public void loadAccountAndPassword()
        {
            UserConfig userConfig = UserConfig.getInstance();
            var inputElms = webBrowser.Document.GetElementsByTagName("input").OfType<HtmlElement>().ToList();
            //<input name = "mcu_pass" type = "password" onkeydown = "if(event.keyCode==13) gosubmit();" size = "20" maxlength = "20" autocomplete = "off" >
            foreach (var elm in inputElms)
            {
                if (elm.GetAttribute("name") == "mcu_no")
                    elm.SetAttribute("value", userConfig.getAccount());
                if (elm.GetAttribute("name") == "mcu_pass")
                    elm.SetAttribute("value", userConfig.getPassword());
            }
        }

        public string getTeacherHomePageLink()
        {
            return "https://www2.mcu.edu.tw";
        }

        public bool isUnderLoginPage()
        {
            return webBrowser.Url.ToString() == @"https://www2.mcu.edu.tw/info/indexNew.asp";
        }

        private List<IHTMLElement> parseElementsFromRollcallFrame(string tagName)
        {
            return parseRollcallFrame().getElementsByTagName(tagName)
                .OfType<IHTMLElement>().ToList();
        }

        private IHTMLElement parseRollcallStudentsTable()
        {
            return parseRollcallFrame().getElementById("ctl00_ContentPlaceHolder1_ChkLStno");
        }

        private IHTMLDocument3 parseRollcallFrame()
        {
            return parseFrameDocument(ROLLCALL_FRAME);
        }

        private IHTMLDocument3 parseFrameDocument(int index)
        {
            object refIndex = (object)index;
            IHTMLDocument2 htmlDoc = (IHTMLDocument2)webBrowser.Document.DomDocument;
            IHTMLWindow2 target_mshtmlIHTMLWindow = (IHTMLWindow2)htmlDoc.frames.item(ref refIndex);
            IHTMLDocument2 target_mshtmlIHTMLDoc = CrossFrameIE.GetDocumentFromWindow(target_mshtmlIHTMLWindow);
            IHTMLDocument3 doc3 = (IHTMLDocument3)target_mshtmlIHTMLDoc;
            return doc3;
        }
    }
}