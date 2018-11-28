using MCR.models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCR.models;
using System.Collections.Concurrent;

namespace MCR.models.repositories
{
    public class StubMcrRepository : McrRepository
    {
        private ConcurrentQueue<Participation> participations = new ConcurrentQueue<Participation>();
        private ConcurrentQueue<Student> students = new ConcurrentQueue<Student>();
        private List<Session> sessions = new List<Session>();

        public void addParticipation(Participation participation)
        {
            var student = students.SingleOrDefault(s => s.id == participation.studentId);
            var session = sessions.SingleOrDefault(s => s.id == participation.sessionId);
            session.students.Add(student);
            participations.Enqueue(participation);
        }

        public Session createSession(Session session)
        {
            session.id = Guid.NewGuid().ToString();
            sessions.Add(session);
            return session;
        }

        public Student createStudent(Student student)
        {
            student.id = Guid.NewGuid().ToString();
            students.Enqueue(student);
            return student;
        }

        public Session getSession(string id)
        {
            return sessions.SingleOrDefault(s => s.id == id);
        }

        public List<Session> getSessions(string ip, string subjectNumber)
        {
            return sessions.Where(s => s.ip == ip && s.subjectNumber == subjectNumber).ToList();
        }

        public List<Session> getSessions()
        {
            return sessions;
        }

        public Student getStudent(string id)
        {
            return students.SingleOrDefault(s => s.id == id);
        }

        public Student getStudent(string ip, string studentId, string name)
        {
            return students.SingleOrDefault(s => s.ip == ip && s.studentId == studentId && s.name == name);
        }

        public List<Student> getStudents()
        {
            return students.ToList();
        }

        public List<Student> getStudents(string ip)
        {
            return students.Where(s => s.ip == ip).ToList();
        }

        public void removeAllSessions()
        {
            sessions.Clear();
        }

        public void removeAllStudents()
        {
            //lock it to prevent different threads clear the queue concurrently.
            lock (this)
            {
                students = new ConcurrentQueue<Student>();
            }
        }

        public void removeParticipation(Participation participation)
        {
            var student = students.SingleOrDefault(s => s.id == participation.studentId);
            var session = sessions.SingleOrDefault(s => s.id == participation.sessionId);
            session.students.Remove(student);
            participations.TryDequeue(out participation);
        }

        public Session removeSession(string id)
        {
            var session = sessions.SingleOrDefault(s => s.id == id);
            sessions.Remove(session);
            return session;
        }

        public Student removeStudent(string id)
        {
            var student = students.SingleOrDefault(s => s.id == id);
            students.TryDequeue(out student);
            return student;
        }

        public void updateSession(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
