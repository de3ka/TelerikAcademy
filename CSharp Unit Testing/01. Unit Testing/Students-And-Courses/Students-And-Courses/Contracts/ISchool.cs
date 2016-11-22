using System.Collections.Generic;

namespace Students_And_Courses.Contracts
{
    public interface ISchool
    {
        IList<ICourse> Courses { get; }

        void AddCourse(ICourse course);

        void RemoveCourse(ICourse course);

        int GetUniqueStudentID();
    }
}
