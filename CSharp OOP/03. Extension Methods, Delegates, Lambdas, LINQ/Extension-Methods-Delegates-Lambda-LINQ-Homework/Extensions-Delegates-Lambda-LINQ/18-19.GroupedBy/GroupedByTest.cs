using Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._18_19.GroupedBy
{
    public class GroupedByTest
    {
        public static void Test()
        {
            var studentList = Initialize();

            Console.WriteLine("\n**********TASK18**********\n");
            Console.WriteLine("-----Extract all students grouped by GroupNumber with LINQ-----\n");

            var groupedStudents = studentList.GroupBy(st => st.GroupNumber);

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

            Console.WriteLine("\n**********TASK19**********\n");
            Console.WriteLine("-----Extract all students grouped by GroupNumber with extension methods-----\n");

            studentList.GroupedByGroupNumber();
        }

        private static List<Student> Initialize()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student("Joro", "Ignatov", 25, 123406,"0240895360", 1,"jorko@gmail.com"),
                new Student("Iskra", "Tshonceva", 18, 123436,  "0244512351",2,"Iskra@gmail.com" ),
                new Student("Eva", "Marinova", 25, 123406, "0984089251", 3,"evito0@abv.bg" ),
                new Student("Sibila", "Kovacheva", 55, 123416, "0884083213", 1,"sibi@abv.bg"),
                new Student("Tina", "Trendafilova", 23, 163256, "0884011123",2,"tina@gmail.com")
            };

            return studentList;
        }
    }
}
