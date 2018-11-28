using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCR.models.repositories;
using MCR.models;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using MCR.fileProcessors;
using System;
using MCR;

namespace UnitTests
{
    [TestClass]
    public class TestMcrRepository
    {
        public static Session testSession = new Session
        {
            name = "TestSession",
            sessionType = Session.SessionType.USER_DEFINED,
            subjectNumber = "Test578",
            ip = "TestIp"
        };

        public static Student testStudent = new Student
        {
            name = "TestStudent",
            studentId = "TestStudentId",
            ip = "TestIp"
        };

        private McrRepository mcrRepository;

        public TestMcrRepository()
        {
            this.mcrRepository = new ReleaseMcrFactory().createMcrRepository();
        }

        [TestMethod]
        public void testStudents()
        {
            //test removing all students
            mcrRepository.removeAllStudents();
            Assert.AreEqual(0, mcrRepository.getStudents().Count);
            Assert.AreEqual(0, mcrRepository.getStudents("TestIp").Count);

            //test creating a student
            Student createdStd = mcrRepository.createStudent(testStudent);
            validateStudent(createdStd, "TestStudent", "TestStudentId", "TestIp");

            //test reading students
            Assert.IsTrue(mcrRepository.getStudents().Contains(createdStd));
            Assert.IsTrue(mcrRepository.getStudents("TestIp").Contains(createdStd));
            Assert.AreEqual(createdStd, mcrRepository.getStudent(createdStd.id));
            validateStudent(createdStd, "TestStudent", "TestStudentId", "TestIp");

            //test reading students under an ip
            Assert.IsTrue(mcrRepository.getStudents("TestIp").Contains(createdStd));

            //test creating 10000 students parallelly
            int lastStudentCount = mcrRepository.getStudents().Count;
            const int nStudent = 50;
            Parallel.For(0, nStudent, (i) => {
                Student std = new Student { name = "Student-" + i, studentId = "TestStudentId-" + i, ip = "TestIp" };
                mcrRepository.createStudent(std);
                validateStudent(std, "Student-" + i, "TestStudentId-" + i, "TestIp");
            });
            Assert.AreEqual(lastStudentCount + nStudent, mcrRepository.getStudents().Count);
        }

        private void validateStudent(Student student, string name, string studentId, string ip)
        {
            Assert.IsNotNull(student.id);
            Assert.AreEqual(student.name, name);
            Assert.AreEqual(student.studentId, studentId);
            Assert.AreEqual(student.ip, ip);
        }

        [TestMethod]
        public void testSessions()
        {
            //test removing all sessions
            mcrRepository.removeAllSessions();
            Assert.AreEqual(0, mcrRepository.getSessions().Count);

            //test creating a session
            Session createdSession = mcrRepository.createSession(testSession);
            validateSession(createdSession, "TestSession", "Test578", "TestIp", Session.SessionType.USER_DEFINED);

            
            ConcurrentQueue<Participation> participations = new ConcurrentQueue<Participation>();
            
            //test adding 10000 participations
            const int nParticipations = 50;
            Parallel.For(0, nParticipations, (i) => {
                Student std = new Student { name = "Student-" + i, studentId = "TestStudentId-" + i, ip = "TestIp" };
                std = mcrRepository.createStudent(std);
                var participation = new Participation { studentId = std.id, sessionId = createdSession.id };
                participations.Enqueue(participation);
                mcrRepository.addParticipation(participation);
            });

            //test read sessions
            Assert.IsTrue(mcrRepository.getSessions().Contains(createdSession));

            createdSession = mcrRepository.getSession(createdSession.id);
            validateSession(createdSession, "TestSession", "Test578", "TestIp", Session.SessionType.USER_DEFINED);
            Assert.AreEqual(nParticipations, createdSession.students.Count);
            
            //remove all participations
            Parallel.ForEach(participations, p => mcrRepository.removeParticipation(p));
            createdSession = mcrRepository.getSession(createdSession.id);
            Assert.AreEqual(0, createdSession.students.Count);
        }

        private void validateSession(Session session, string name, string subjectNumber, string ip, Session.SessionType sessionType)
        {
            Assert.IsNotNull(session.id);
            Assert.AreEqual(session.name, name);
            Assert.AreEqual(session.subjectNumber, subjectNumber);
            Assert.AreEqual(session.sessionType, sessionType);
            Assert.AreEqual(session.ip, ip);
        }
    }
}
