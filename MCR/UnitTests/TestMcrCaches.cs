using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCR.fileProcessors;
using MCR.models.repositories;
using System.Collections.Generic;
using MCR.models;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TestMcrCaches
    {
        [TestMethod]
        public void mcrCachesShouldBeFasterThanWithoutCache()
        {
            var withouCacheMcrRP = new ApringFileMcrRepository(new TxtFileProcessor());
            var cacheMcrRP = new CacheFileMcrRepositoryProxy(
                                new ApringFileMcrRepository(
                                new TxtFileProcessor()));

            Console.WriteLine("Doing cache.");
            var cacheMcrTimeWaste = runTaskAndReturnTimeWaste(cacheMcrRP);
            Console.WriteLine("Cache waste: " + cacheMcrTimeWaste);
            Console.WriteLine("Doing without cache.");
            var withoutCacheTimeWaste = runTaskAndReturnTimeWaste(withouCacheMcrRP);
            Console.WriteLine("Without Cache waste: " + withoutCacheTimeWaste);
            Assert.IsTrue(withoutCacheTimeWaste > cacheMcrTimeWaste);
        }

        private double runTaskAndReturnTimeWaste(McrRepository mcrRepository)
        {
            const int LOOP = 30;
            var start = DateTime.Now;

            //test repeated Creation and Removing
            Parallel.For(0, LOOP, (i) =>
            {
                var student = new Student() { name = "test" + i, ip = "testIp", studentId = "testStdId" };
                var session = new Session() { name = "test" + i, ip = "testIp", subjectNumber = "testSubject" };
                student = mcrRepository.createStudent(student);
                session = mcrRepository.createSession(session);
            });

            //test session participatants
            var testedSession = new Session() { name = "test", ip = "testIp", subjectNumber = "testSubject" };
            testedSession = mcrRepository.createSession(testedSession);
            Parallel.ForEach(mcrRepository.getStudents(), (s) => 
                mcrRepository.addParticipation(new Participation(testedSession.id, s.id)));

            testedSession = mcrRepository.getSession(testedSession.id);
            Assert.AreEqual(testedSession.students.Count, mcrRepository.getStudents().Count);


            List<Student> students = mcrRepository.getStudents();
            List<Session> sessions = mcrRepository.getSessions();

            //test repeated Get
            Parallel.For(0, LOOP, (i) =>
            {
                Assert.AreEqual(students.Count, mcrRepository.getStudents().Count);
                Assert.AreEqual(sessions.Count, mcrRepository.getSessions().Count);
            });

            Parallel.ForEach(mcrRepository.getStudents(), (s) =>
                mcrRepository.removeStudent(s.id));
            Parallel.ForEach(mcrRepository.getSessions(), (s) =>
                mcrRepository.removeSession(s.id));

            Assert.AreEqual(0, mcrRepository.getSessions().Count);
            Assert.AreEqual(0, mcrRepository.getStudents().Count);
            return (DateTime.Now - start).TotalMilliseconds;
        }
    }
}
