using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using MCR.fileProcessors;

namespace MCR.models.repositories
{
    /// <summary>
    /// @Author Wang Ning
    /// Use GUID as id.
    /// </summary>
    public class ApringFileMcrRepository : McrRepository
    {
        public const string PARTICIPATIONS_NAME = @"participations.arping";
        public const string SESSIONS_NAME = @"sessions.arping";
        public const string STUDENTS_NAME = @"students.arping";

        private FileProcessor fileProcessor;

        public ApringFileMcrRepository(FileProcessor fileProcessor)
        {
            this.fileProcessor = fileProcessor;
        }

        public void addParticipation(Participation participation)
        {
            lock (PARTICIPATIONS_NAME)
            {
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                participations.Add(participation);
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));
            }
        }

        public void removeParticipation(Participation participation)
        {
            lock (PARTICIPATIONS_NAME)
            {
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                participations.Remove(participation);
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));
            }
        }

        public Session createSession(Session session)
        {
            lock (SESSIONS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                session.id = session.id == null ? Guid.NewGuid().ToString() : session.id;
                sessions.Add(session);
                fileProcessor.write(SESSIONS_NAME, JsonConvert.SerializeObject(sessions));
                return session;
            }
        }

        public Student createStudent(Student student)
        {
            lock (STUDENTS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                student.id = student.id == null ? Guid.NewGuid().ToString() : student.id;
                students.Add(student);
                fileProcessor.write(STUDENTS_NAME, JsonConvert.SerializeObject(students));
                return student;
            }
        }

        public void updateSession(Session session)
        {
            lock (SESSIONS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                fileProcessor.write(SESSIONS_NAME, JsonConvert.SerializeObject(sessions));
                Session oldSession = sessions.SingleOrDefault(s => s.id == session.id);
                sessions.Remove(oldSession);
                sessions.Add(session);
                fileProcessor.write(SESSIONS_NAME, JsonConvert.SerializeObject(sessions));
            }
        }

        public Session getSession(string id)
        {
            lock (SESSIONS_NAME)
            lock (PARTICIPATIONS_NAME)
            lock (STUDENTS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                var session = sessions.SingleOrDefault(s => s.id == id);
                foreach (var participation in participations)
                {
                    if (participation.sessionId == id)
                    {
                        session.students.Add(students.SingleOrDefault(st => st.id == participation.studentId));
                    }
                }
                return session;
            }
        }

        public List<Session> getSessions(string ip, string subjectNumber)
        {
            lock (SESSIONS_NAME)
            lock (PARTICIPATIONS_NAME)
            lock (STUDENTS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                var sessionsWithCondition = sessions.Where(s => s.ip == ip && s.subjectNumber == subjectNumber).ToList();
                foreach (var session in sessionsWithCondition)
                {
                    foreach (var participation in participations)
                    {
                        if (participation.sessionId == session.id)
                        {
                            session.students.Add(students.SingleOrDefault(st => st.id == participation.studentId));
                        }
                    }
                }
                return sessionsWithCondition;
            }
        }

        public List<Session> getSessions()
        {
            lock (SESSIONS_NAME)
            lock (PARTICIPATIONS_NAME)
            lock (STUDENTS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                foreach (var participation in participations)
                {
                    foreach (var session in sessions)
                    {
                        if (session.id == participation.sessionId)
                        {
                            session.students.Add(students.SingleOrDefault(st => st.id == participation.studentId));
                        }
                    }
                }
                return sessions;
            }
        }

        public Student getStudent(string id)
        {
            lock (STUDENTS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                return students.SingleOrDefault(s => s.id == id);
            }
        }
        
        public Student getStudent(string ip, string studentId, string name)
        {
            lock (STUDENTS_NAME)
                return getStudents(ip).SingleOrDefault(s => s.ip == ip
                                                && s.studentId == studentId
                                                 && s.name == name);
        }

        public List<Student> getStudents()
        {
            lock (STUDENTS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                return students;
            }
        }

        public List<Student> getStudents(string ip)
        {
            lock (STUDENTS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                return students.Where(s => s.ip == ip).ToList();
            }
        }

        public void removeAllSessions()
        {
            lock (SESSIONS_NAME)
            lock (PARTICIPATIONS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                foreach (var session in sessions)
                {
                    var participationsToRemove = participations.Where(r => r.sessionId == session.id);
                    foreach (var participationToRemove in participationsToRemove)
                    {
                        participations.Remove(participationToRemove);
                    }
                }
                fileProcessor.write(SESSIONS_NAME, "");
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));
            }
        }

        public void removeAllStudents()
        {
            lock (STUDENTS_NAME)
            lock (PARTICIPATIONS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));

                foreach (var student in students.ToArray())
                {
                    var participationsToRemove = participations.Where(r => r.studentId == student.id);
                    foreach (var participationToRemove in participationsToRemove.ToArray())
                    {
                        participations.Remove(participationToRemove);
                    }
                }
                fileProcessor.write(STUDENTS_NAME, "");
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));
            }
        }

        public Session removeSession(string id)
        {
            lock (SESSIONS_NAME)
            lock (PARTICIPATIONS_NAME)
            {
                var sessions = JsonConvert.DeserializeObject<List<Session>>(emptyArrayIfNull(SESSIONS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));
                Session session = sessions.SingleOrDefault(s => s.id == id);
                sessions.Remove(session);

                var itemsToRemove = participations.Where(r => r.sessionId == id).ToArray();
                foreach (var itemToRemove in itemsToRemove)
                    participations.Remove(itemToRemove);

                fileProcessor.write(SESSIONS_NAME, JsonConvert.SerializeObject(sessions));
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));

                return session;
            }
        }

        public Student removeStudent(string id)
        {
            lock (STUDENTS_NAME)
            lock (PARTICIPATIONS_NAME)
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(emptyArrayIfNull(STUDENTS_NAME));
                var participations = JsonConvert.DeserializeObject<List<Participation>>(emptyArrayIfNull(PARTICIPATIONS_NAME));

                Student student = students.SingleOrDefault(s => s.id == id);
                students.Remove(student);

                var itemsToRemove = participations.Where(r => r.studentId == id).ToList();
                foreach (var itemToRemove in itemsToRemove)
                {
                    participations.Remove(itemToRemove);
                }

                fileProcessor.write(STUDENTS_NAME, JsonConvert.SerializeObject(students));
                fileProcessor.write(PARTICIPATIONS_NAME, JsonConvert.SerializeObject(participations));
                return student;
            }
        }

        private string emptyArrayIfNull(string fileName)
        {
            var content = fileProcessor.read(fileName);
            return string.IsNullOrEmpty(content) ? "[]" : content;
        }
    }
}
