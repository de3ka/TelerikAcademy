using System.Collections.Generic;

namespace Students_And_Courses.Contracts
{
    public interface ICourse
    {
        string Name { get; }

        IList<IStudent> Students { get; }

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);
    }
}
