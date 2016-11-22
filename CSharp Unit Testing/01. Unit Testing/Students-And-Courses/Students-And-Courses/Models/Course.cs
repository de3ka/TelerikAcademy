using System;
using System.Collections.Generic;
using Students_And_Courses.Common;
using Students_And_Courses.Contracts;

namespace Students_And_Courses.Models
{
    public class Course : ICourse
    {
        private IList<IStudent> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<IStudent>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfEmptyStringOrNull(value);
                Validator.CheckIfValueInRange(value.Length, 0, 100, "CourseName");
                this.name = value;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }

            private set
            {
                Validator.CheckIfNull<IList<IStudent>>(value, "StudentsInCourse");
                this.students = value;
            }
        }

        public void AddStudent(IStudent student)
        {
            Validator.CheckIfNull<IStudent>(student);

            if (this.students.Count >= GlobalConstants.MaxStudentsInCourse)
            {
                throw new ArgumentOutOfRangeException("Courses cannot exceed more than 30 students per each.");
            }

            CheckIfStudentIsInCourse(student);

            this.students.Add(student);
        }

        private void CheckIfStudentIsInCourse(IStudent student)
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (student.Equals(this.students[i]))
                {
                    throw new ArgumentException("Student already enlisted in course.");
                }
            }
        }

        public void RemoveStudent(IStudent student)
        {
            Validator.CheckIfNull<IStudent>(student);
            var indexOfStudent = FindFirstIndex(student);

            if (indexOfStudent < 0)
            {
                throw new ArgumentException("Student cannot be found.");
            }

            this.students.RemoveAt(indexOfStudent);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Course;
            return (this.Name == other.Name) && (this.students.Equals(other.students));
        }

        private int FindFirstIndex(IStudent student)
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (student.Equals(this.students[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
