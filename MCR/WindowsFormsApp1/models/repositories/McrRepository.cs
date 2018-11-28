using System.Collections.Generic;

namespace MCR.models.repositories
{
    public interface McrRepository
    {
        /// <returns> the created session </returns>
        Session createSession(Session session);

        /// <summary>
        /// Remove the session, notice that all the participations under the session 
        /// would also be removed once the session is removed.
        /// </summary>
        /// <returns> the removed session </returns>
        Session removeSession(string id);

        /// <summary>
        /// Remove all sessions, notice that all the participations under the session 
        /// would also be removed once the session is removed.
        /// </summary>
        void removeAllSessions();

        Session getSession(string id);

        /// <returns> the specific sessions. </returns>
        List<Session> getSessions(string ip, string subjectNumber);

        /// <returns> all sessions </returns>
        List<Session> getSessions();

        /// <summary>
        /// Update an existing session.
        /// </summary>
        void updateSession(Session session);

        /// <returns> the created student </returns>
        Student createStudent(Student student);

        Student getStudent(string id);

        Student getStudent(string ip, string studentId, string name);

        /// <returns> all students </returns>
        List<Student> getStudents();
        
        /// <returns> students under the ip </returns>
        List<Student> getStudents(string ip);

        /// <summary>
        /// Remove the student, notice that all the participations the student owns 
        /// would also be removed once the student is removed.
        /// </summary>
        /// <returns> removed student </returns>
        Student removeStudent(string id);

        /// <summary>
        /// Remove all students, notice that all the participations the student owns
        /// would also be removed once each student is removed.
        /// </summary>
        void removeAllStudents();
        
        void addParticipation(Participation participation);
        
        void removeParticipation(Participation participation);
    }
}
