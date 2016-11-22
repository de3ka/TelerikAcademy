using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students_And_Courses.Models;
using Students_And_Courses.Contracts;

namespace Students_And_Courses.Test
{
    [TestClass]
    public class CourseTest
    {
        private Student GetValidStudent()
        {
            var school = GetValidSchool();
            var student = new Student("Valid", school);

            return student;
        }

        private School GetValidSchool()
        {
            var school = new School("Valid");
            return school;
        }

        private Course GetValidCourse()
        {
            var course = new Course("Valid");
            return course;
        }

        [TestMethod]
        public void Creating_Course_Should_Succeed_When_Provided_Valid_Data()
        {
            var course = GetValidCourse();

            Assert.IsInstanceOfType(course, typeof(ICourse), "Creating course failed with valid data.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Creating_Course_Should_Throw_ArgumentException_When_Provided_Empty_Name()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Creating_Course_Should_Throw_ArgumentException_When_Provided_Too_Long_Name()
        {
            var tooLongName = new string('a', 101);
            var course = new Course(tooLongName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Creating_Course_Should_Throw_ArgumentException_When_Provided_Name_With_Null_Value()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void Add_Student_To_Course_Should_Succeed_When_Provided_Valid_Data()
        {
            var student = GetValidStudent();
            var course = GetValidCourse();

            course.AddStudent(student);

            Assert.AreEqual(course.Students[0], student, "Adding one student should add the same object.");
            Assert.AreEqual<int>(1, course.Students.Count,
                string.Format("Number of students in course: {0} is incorrect", course.Students.Count));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Student_To_Course_Should_Throw_ArgumentNullException_When_Provided_Null_Students()
        {
            var course = GetValidCourse();
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_Student_Should_Throw_ArgumentOutOfRangeException_When_Provided_More_Than_Thirty()
        {
            var course = GetValidCourse();
            School school = GetValidSchool();

            for (int i = 0; i < 31; i++)
            {
                var currStudent = new Student("KTX-" + i, school);
                course.AddStudent(currStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Student_Should_Throw_ArgumentException_When_Adding_Same_Student()
        {
            var course = GetValidCourse();
            var student = GetValidStudent();

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void Remove_Student_Should_Succeed_When_Provided_Valid_Data()
        {
            var course = GetValidCourse();
            var student = GetValidStudent();
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual<int>(0, course.Students.Count, "Removing student failed with valid data.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_Student_Should_Throw_ArgumentException_When_Removing_Not_Added_Student()
        {
            var course = GetValidCourse();
            var student = GetValidStudent();
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_Student_Should_Throw_ArgumentException_When_Removing_Null()
        {
            var course = GetValidCourse();
            course.RemoveStudent(null);
        }

        [TestMethod]
        public void Students_Property_Should_Return_New_List_When_Using_Getter()
        {
            var course = GetValidCourse();
            var students = course.Students;
            var student = GetValidStudent();

            students.Add(student);

            Assert.AreNotEqual(students, course.Students, "Getting students list returned same reference.");
        }
    }
}
