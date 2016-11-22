using Students_And_Courses.Common;
using Students_And_Courses.Contracts;

namespace Students_And_Courses.Models
{
    public class Student : IStudent
    {
        private string name;
        private int id;

        public Student(string name, ISchool schoolEnrolledIn)
        {
            this.Name = name;
            Validator.CheckIfNull<ISchool>(schoolEnrolledIn);
            this.ID = schoolEnrolledIn.GetUniqueStudentID();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfEmptyStringOrNull(value, "Name");
                Validator.CheckIfValueInRange(value.Length, 1, 100, "Name");
                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                Validator.CheckIfNull<int>(value);
                Validator.CheckIfValueInRange(value, GlobalConstants.UniqueIdStart, GlobalConstants.UniqueIdEnd, "ID");

                this.id = value;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Student;
            return (this.ID == other.ID) && (this.Name == other.Name);
        }
    }
}
