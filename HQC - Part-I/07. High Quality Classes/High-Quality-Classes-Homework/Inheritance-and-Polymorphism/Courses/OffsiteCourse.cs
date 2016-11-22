using System.Collections.Generic;
using System.Text;
using Inheritance_and_Polymorphism.Helpers;

namespace Inheritance_and_Polymorphism.Courses
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, string town)
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                Validator.ValidateIfNullOrEmpty(value, "course name");
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString().Trim('}').Trim());
            sb.AppendLine(string.Format("; {0} }}", this.Town));
            return sb.ToString().Trim();
        }
    }
}
