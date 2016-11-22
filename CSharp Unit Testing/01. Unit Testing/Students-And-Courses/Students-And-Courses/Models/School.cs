using System;
using System.Collections.Generic;
using Students_And_Courses.Common;
using Students_And_Courses.Contracts;

namespace Students_And_Courses.Models
{
    public class School : ISchool
    {

        private string name;
        private IList<int> studentIDs;
        private IList<ICourse> courses;

        private int nextStudentID;

        public School(string name)
        {
            this.Name = name;
            this.studentIDs = new List<int>();
            this.Courses = new List<ICourse>();
            this.nextStudentID = GlobalConstants.UniqueIdStart;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfEmptyStringOrNull(value, "SchoolName");
                Validator.CheckIfValueInRange(value.Length, 0, 100, "SchoolName");
                this.name = value;
            }
        }

        public IList<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
            private set
            {
                Validator.CheckIfNull<IList<ICourse>>(value, "Courses");
                this.courses = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            Validator.CheckIfNull<ICourse>(course);
            var indexOfCourse = FindFirstIndex(course);

            if (!(indexOfCourse < 0))
            {
                throw new ArgumentException("Course is already listed in the school.");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(ICourse course)
        {
            Validator.CheckIfNull<ICourse>(course);
            var indexOfCourse = FindFirstIndex(course);

            if (indexOfCourse < 0)
            {
                throw new ArgumentException("Course could not be found.");
            }

            this.courses.RemoveAt(indexOfCourse);
        }

        public int GetUniqueStudentID()
        {
            return ++this.nextStudentID;
        }

        private int FindFirstIndex(ICourse course)
        {
            for (int i = 0; i < this.courses.Count; i++)
            {
                if (course.Equals(this.courses[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
