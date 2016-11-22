using Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._18_19.GroupedBy
{
    public static class GroupedByExtensions
    {
        public static void GroupedByGroupNumber(this List<Student> studentsList)
        {
            var groupedStudents = studentsList
                .GroupBy(st => st.GroupNumber);

            int i = 1;
            foreach (var students in groupedStudents)
            {
                Console.WriteLine("Group {0}", i);
                foreach (var student in students)
                {
                    if (i == 0)
                    {
                        Console.WriteLine(student.GroupNumber);
                    }

                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }

                Console.WriteLine();
                i++;
            }
        }
    }
}
