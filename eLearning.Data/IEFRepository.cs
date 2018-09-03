using System.Collections.Generic;
using eLearning.Domain;

namespace eLearning.Data
{
    public interface IEFRepository
    {
        Course GetCourse(int id, bool includeDetails = false);
        IEnumerable<Course> GetCourses(bool includeDetails = false);
        Subject GetSubject(int id, bool includeDetails = false);
        IEnumerable<Subject> GetSubjects(bool includeDetails = false);

        void Add(object entity);
        void Remove(object entity);
        bool SaveChanges();
        void Update(object entity);
    }
}