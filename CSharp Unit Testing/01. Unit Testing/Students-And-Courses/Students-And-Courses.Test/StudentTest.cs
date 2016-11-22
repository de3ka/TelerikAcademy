using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students_And_Courses.Models;
using Students_And_Courses.Contracts;

namespace Students_And_Courses.Test
{
    [TestClass]
    public class StudentTest
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

        [TestMethod]
        public void Creating_Student_Should_Succeed_When_Provided_Valid_Data()
        {
            var student = GetValidStudent();

            Assert.IsInstanceOfType(student, typeof(IStudent));
            Assert.IsNotNull(student.ID, "Student cannot have ID equal to null.");
            Assert.IsNotNull(student.Name, "Student cannot have name equal to null.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Creating_Student_Should_Trow_ArgumentException_When_Given_Name_With_Null_Value()
        {
            var school = GetValidSchool();
            var student = new Student(null, school);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Creating_Student_Should_Throw_ArgumentException_When_Given_Empty_Name()
        {
            var school = GetValidSchool();
            var student = new Student(string.Empty, school);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Creating_Student_Should_Throw_ArgumentOutOfRangeException_When_Given_Too_Long_Name()
        {
            var school = new School("FELS");
            var tooLongName = new string('a', 101);
            var student = new Student(tooLongName, school);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Creating_Student_Should_Throw_ArgumentNullException_When_Given_School_With_Null_Value()
        {
            var student = new Student("Marry", null);
        }

        [TestMethod]
        public void Students_Should_Have_Different_IDs_If_In_One_School()
        {
            var school = new School("FELS");

            var firstStudent = new Student("John", school);
            var secondStudent = new Student("Marry", school);

            Assert.AreNotEqual(firstStudent.ID, secondStudent.ID,
                "Students in one school cannot have same ID.");
        }

        [TestMethod]
        public void Students_Can_Have_Same_ID_If_In_Different_Schools()
        {
            var firstSchool = new School("FELS");
            var secondSchool = new School("FGLS");

            var studentInFirstSchool = new Student("Sophie", firstSchool);
            var studentInSecondSchool = new Student("Leonardo", secondSchool);

            Assert.AreEqual(studentInFirstSchool.ID, studentInSecondSchool.ID,
                "Adding first students in different schools should give them same ID.");
        }
    }
}
