using System.Collections.Generic;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups
{
    public static class StudentListExtensions
    {
        public static List<Student> FindStudentsFromGroup2(this List<Student> studentsList)
        {
            var studentsFromGroup2 = studentsList
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName).ToList();

            return studentsFromGroup2;
        }

        public static List<Student> ExtraxtStudentsWithMark2(this List<Student> studentsList)
        {
            var weakStudents = new List<Student>();

            foreach (var student in studentsList)
            {
                int counter = 0;

                foreach (var mark in student.Marks)
                {
                    if (mark == 2)
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    weakStudents.Add(student);
                }
            }

            return weakStudents;
        }
    }
}
