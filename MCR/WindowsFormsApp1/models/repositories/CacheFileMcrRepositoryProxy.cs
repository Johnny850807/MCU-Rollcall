using MCR.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MCR.models.repositories
{
    /// <summary>
    /// The repository implements a cache proxy which handles the caches of each I/O.
    /// 
    /// Opmistic I/O operations, the main problem of the cache would be we
    /// are not detecting any I/O exception in the current version.
    /// </summary>
    /// TODO waterball
    public class CacheFileMcrRepositoryProxy : McrRepository
    {
        private const string TAG = "CacheMcrProxy";
        private int numStudentsReader = 0;
        private int numSessionsReader = 0;
        private object studentsLock = 1;
        private object sessionsLock = 2;
        private Dictionary<string, Student> studentsCache = new Dictionary<string, Student>();
        private Dictionary<string, Session> sessionsCache = new Dictionary<string, Session>();
        private McrRepository mcrRepository;

        public CacheFileMcrRepositoryProxy(McrRepository mcrRepository)
        {
            this.mcrRepository = mcrRepository;
            Log.d(TAG, "Initializing all caches...");
            foreach (var student in mcrRepository.getStudents())
                studentsCache[student.id] = student;
            foreach (var session in mcrRepository.getSessions())
                sessionsCache[session.id] = session;
            Log.d(TAG, "Caches setup successfully. Students: " + studentsCache.Count() + 
                            ", Sessions: " + sessionsCache.Count());
        }

        public Session removeSession(string id)
        {
            lock(sessionsLock)
            {
                var session = sessionsCache[id];
                ThreadPool.QueueUserWorkItem(o=> mcrRepository.removeSession(id));
                sessionsCache.Remove(id);
                return session;
            }
        }

        public void removeAllSessions()
        {
            lock (sessionsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.removeAllSessions());
                sessionsCache.Clear();
            }
        }

        public Session getSession(string id)
        {
            lock (sessionsLock)
                return sessionsCache[id];
        }

        public Session createSession(Session session)
        {
            lock (sessionsLock)
            {
                session.id = session.id == null ? Guid.NewGuid().ToString() : session.id;
                ThreadPool.QueueUserWorkItem(o => mcrRepository.createSession(session));
                sessionsCache[session.id] = session;
                return session;
            }
        }
        
        public List<Session> getSessions(string ip, string subjectNumber)
        {
            lock (sessionsLock)
            {
                return sessionsCache.Values.Where(s => s.ip == ip &&
                s.subjectNumber == subjectNumber).ToList();
            }
        }

        public List<Session> getSessions()
        {
            lock (sessionsLock)
            {
                return sessionsCache.Values.ToList();
            }
        }

        public Student getStudent(string ip, string studentId, string name)
        {
            lock(studentsLock)
            {
                return studentsCache.Values.SingleOrDefault(s => s.ip == ip
                                                && s.studentId == studentId
                                                 && s.name == name);
            }
        }

        public Student getStudent(string id)
        {
            lock (studentsLock)
            {
                return studentsCache[id];
            }
        }

        public List<Student> getStudents()
        {
            lock (studentsLock)
            {
                return studentsCache.Values.ToList();
            }
        }

        public List<Student> getStudents(string ip)
        {
            lock (studentsLock)
            {
                return studentsCache.Values.Where(s => s.ip == ip).ToList();
            }
        }

        public Student createStudent(Student student)
        {
            lock (studentsLock)
            {
                student.id = student.id == null ? Guid.NewGuid().ToString() : student.id;
                ThreadPool.QueueUserWorkItem(o => mcrRepository.createStudent(student));
                studentsCache[student.id] = student;
                return student;
            }
        }

        public void addParticipation(Participation participation)
        {
            lock (sessionsLock)
            lock (studentsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.addParticipation(participation));
                var session = sessionsCache[participation.sessionId];
                var student = studentsCache[participation.studentId];
                session.students.Add(student);
            }
        }

        public void removeParticipation(Participation participation)
        {
            lock (sessionsLock)
            lock (studentsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.removeParticipation(participation));
                var session = sessionsCache[participation.sessionId];
                var student = studentsCache[participation.studentId];
                session.students.Remove(student);
            }
        }

        public Student removeStudent(string id)
        {
            lock (studentsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.removeStudent(id));
                var student = studentsCache[id];
                studentsCache.Remove(id);
                foreach (var session in sessionsCache.Values)
                    session.students.Remove(student);
                return student;
            }
        }

        public void removeAllStudents()
        {
            lock (studentsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.removeAllStudents());
                studentsCache.Clear();
            }
        }

        public void updateSession(Session session)
        {
            lock(sessionsLock)
            {
                ThreadPool.QueueUserWorkItem(o => mcrRepository.updateSession(session));
                sessionsCache[session.id] = session;
            }
        }
    }
}
