using System;
using System.Linq;
using System.Net;
using MCR.models.repositories;
using System.IO;
using MCR.models;
using MCR.utils;
using MCR.exceptions;
using System.Web;

namespace MCR.server
{
    /// <summary> Author: Waterball
    /// /Sign/api
    /// </summary>
    public class SignController : RollCallController
    {
        private static char COOKIE_DELIMITER = ':';
        private static string TAG = "SignController";

        private const string SIGN_UP_HTML = "../signUp.html";
        private const string STUDENTID_INVALID_HTML = "../studentFormatInvalid.html";
        private const string STUDENT_IDENTITY_BLOCKED_HTML = "../studentIdentityBlocked.html";
        private const string SIGN_IN_SUCCESSFULLY_HTML = "../signInSuccessfully.html";
        private const string SIGN_UP_SUCCESSFULLY_HTML = "../signUpSuccessfully.html";
        private const string STATUS_INVALID_HTML = "../statusInvalid.html";

        public static class APIs
        {
            public const string API_SIGN_IN = "signIn";
            public const string API_SIGN_UP = "signUp";
        }

        public static class Keys
        {
            public const string QRCODE_TOKEN = "qrCodeToken";
            public const string NAME = "name";
            public const string STUDENT_ID = "studentId";
            public const string ID = "id";
            public const string IDENTITY = "identity";
        }
        
        private McrRepository mcrRepository;
        private Session session;
        private Cookie identityCookie;

        public SignController(McrRepository mcrRepository,
            HttpListenerContext client, RollcallServer server, Session session) : base(client, server)
        {
            var encoding = request.ContentEncoding;
            this.mcrRepository = mcrRepository;
            this.session = session;
            identityCookie = request.Cookies[Keys.IDENTITY];
        }

        public override void handleRequest()
        {
            var api = request.Url.Segments[2].TrimEnd('/');
            DateTime start = DateTime.Now;
            switch (api)
            {
                case APIs.API_SIGN_IN:
                    api_signIn();
                    break;
                case APIs.API_SIGN_UP:
                    api_signUp();
                    break;
            }
            var diff = (DateTime.Now - start).Milliseconds;
            Log.d(TAG, "New request, spent: " + diff + " ms.");
        }

        public void api_signIn()
        {
            if (qRCodeTokenExpired())
            {
                response.Redirect(STATUS_INVALID_HTML);
                return;
            }

            if (isCookieEmptyOrInvalid())
                response.Redirect(SIGN_UP_HTML);
            else  //start validating student's identity and then update the rollcall state
            {
                var student = createStudentFromCookies();
                if (isStudentIdentityLegal(student))
                {
                    if (!studentExistsUnderServerIp(student))
                        createAndSaveStudentToDisk(student);
                    createParticipationIfUserDefinedAndStudentNotInSession(student);
                    signInStudentAndRedirectSuccessPage(student);
                }
                else
                {
                    response.Redirect(STUDENT_IDENTITY_BLOCKED_HTML);
                    server.blockStudent(student);
                    Log.d(TAG, "Student " + student + " blocked.");
                }
            }
        }

        private Student createAndSaveStudentToDisk(Student student)
        {
            student.expires = DateTime.Now.AddMonths(1);
            student = mcrRepository.createStudent(student);
            Log.d(TAG, "Student " + student + "created.");
            return student;
        }

        private bool qRCodeTokenExpired()
        {
            return !(request.QueryString[Keys.QRCODE_TOKEN] == server.getQRCodeToken() || request.QueryString[Keys.QRCODE_TOKEN] == server.getPreQRCodeToken() );
        }

        private bool isCookieEmptyOrInvalid()
        {
            return identityCookie == null || string.IsNullOrEmpty(identityCookie.Value)
                || identityCookie.Value.Split(COOKIE_DELIMITER).Length != 3;
        }

        private Student createStudentFromCookies()
        {
            var properties = identityCookie.Value.Split(COOKIE_DELIMITER);
            return new Student()
            {
                ip = server.ip,
                id = properties[0],
                name = HttpUtility.UrlDecode(properties[1]).Replace(" ",""),
                studentId = properties[2]
            };
        }
        
        private bool isStudentIdentityLegal(Student student)
        {
            try
            {
                var identity = mcrRepository.getStudents()
                    .SingleOrDefault(s => s.studentId == student.studentId
                    && s.ip == student.ip);
                // If the studentId exists but with a different token, 
                // then cookie might be changed manually and illegally by student.
                return identity == null || identity.id == student.id;
            } catch (Exception err)
            {
                var msg = "Error - found dupliated same student identities.";
                Log.err(TAG, msg, err);
                throw new RollcallStateException(msg, err);
            }
        }
        
        private bool studentExistsUnderServerIp(Student student)
        {
            return mcrRepository.getStudents(server.ip)
                .Count(s => s.id == student.id) != 0;
        }

        private void createParticipationIfUserDefinedAndStudentNotInSession(Student student)
        {
            if (session.sessionType == Session.SessionType.USER_DEFINED 
                && !session.students.Contains(student))
            {
                mcrRepository.addParticipation(new Participation(session.id, student.id));
                session.students.Add(student);
                Log.d(TAG, "Participation between " + student.name + " and " + session.name + " created.");
            }
            else
                Log.d(TAG, "Participation between " + student.name + " and " + session.name + " exists.");
        }

        private void signInStudentAndRedirectSuccessPage(Student student)
        {
            server.signStudent(student);
            response.Redirect(SIGN_IN_SUCCESSFULLY_HTML);
            Log.d(TAG, "Student " + student + "signed in successfully.");
        }

        public void api_signUp()
        {
            var student = createStudentFromQueryString();
            if (isStudentIdentityLegal(student))
            {
                var token = Guid.NewGuid().ToString();
                Log.d(TAG, "Student valid, create token " + token + " for " + student.name + ".");
                student.id = token;
                saveStudentIdentityToCookie(student);
                createAndSaveStudentToDisk(student);
                response.Redirect(SIGN_UP_SUCCESSFULLY_HTML);
            }
            else
                response.Redirect(STUDENT_IDENTITY_BLOCKED_HTML);
        }

        private Student createStudentFromQueryString()
        {
            var queryNamePair = HttpUtility.ParseQueryString(request.Url.Query);
            var studentId = queryNamePair[Keys.STUDENT_ID];
            var name = queryNamePair[Keys.NAME];
            return new Student()
            {
                studentId = studentId,
                ip = server.ip,
                name = name.Replace(" ", "")
            };
        }

        private void saveStudentIdentityToCookie(Student student)
        {
            var identity = student.id + COOKIE_DELIMITER + HttpUtility.UrlEncode(student.name)
                + COOKIE_DELIMITER + student.studentId;
            var identityCookie = new Cookie(Keys.IDENTITY, identity) { Expires = DateTime.Now.AddMonths(1) };
            response.AppendCookie(identityCookie);
            Log.d(TAG, "Student " + student + " saved into the cookie["+ identityCookie+"].");
        }

        private bool validateStudentIdFormat(string studentId)
        {
            //TODO regex
            return true;
        }
    }
}
