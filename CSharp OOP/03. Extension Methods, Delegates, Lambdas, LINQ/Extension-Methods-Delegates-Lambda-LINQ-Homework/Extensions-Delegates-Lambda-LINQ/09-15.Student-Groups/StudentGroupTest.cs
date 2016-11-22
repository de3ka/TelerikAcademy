using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups
{
    public class StudentGroupTest
    {
        public static void Test()
        {

            var studentList = Initialize();

            Console.WriteLine("\n**********TASK9**********\n");
            Console.WriteLine("-----Ordering students from group 2 by first name with LINQ-----\n");
            var studetnsFromGroup2 = studentList
               .Where(st => st.GroupNumber == 2)
               .OrderBy(st => st.FirstName)
               .ToList();

            foreach (var student in studetnsFromGroup2)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + "    Group: " + student.GroupNumber);
            }

            Console.WriteLine("\n**********TASK10**********\n");

            Console.WriteLine("-----Ordering students from group 2 by first name with Expr Method-----\n");

            var secondListofStudentsGroup2 = studentList.FindStudentsFromGroup2();

            foreach (var student in secondListofStudentsGroup2)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + "    Group: " + student.GroupNumber);
            }

            Console.WriteLine("\n**********TASK11**********\n");

            Console.WriteLine("-----Extract all students that have email in abv.bg-----\n");

            var extractedStudents = studentList
               .Where(st => st.Email.Contains("abv.bg"))
               .ToList();

            foreach (var student in extractedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + "   email: " + student.Email);
            }


            Console.WriteLine("\n**********TASK12**********\n");

            Console.WriteLine("-----Extract all students with phones in Sofia with LINQ-----\n");
            var studentFromSofia = studentList
                .Where(st => st.PhoneNumber[0] == '0' && st.PhoneNumber[1] == '2')
                .ToList();

            foreach (var student in studentFromSofia)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + "   tel: " + student.PhoneNumber);
            }

            Console.WriteLine("\n**********TASK13**********\n");

            Console.WriteLine("-----Students that have at least one mark Excellent (6)-----\n");

            var studentsWith6 = studentList
                .Where(st => st.Marks.Contains(6))
                .ToList();

            var anonymousType = new
            {
                FullName = studentsWith6.Select(st => st.FirstName + " " + st.LastName),
                Marks = studentsWith6.Select(st => st.Marks)
            };


            foreach (var name in anonymousType.FullName)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("\n**********TASK14**********\n");

            Console.WriteLine("-----Extract the students with exactly two marks " + @"""2""-----" + "\n");
            var weakStudents = studentList.ExtraxtStudentsWithMark2();

            foreach (var student in weakStudents)
            {
                Console.Write(student.FirstName + " " + student.LastName + "   Marks: ");
                Console.WriteLine(string.Join(", ", student.Marks));
            }


            Console.WriteLine("\n**********TASK15**********\n");

            Console.WriteLine("-----Extract all Marks of the students that enrolled in 2006-----\n");

            var studentsFrom06 = studentList
               .Where(st => st.FacNumber.ToString().Substring(4, 2) == "06")
               .Select(st => st.Marks)
               .ToList();

            foreach (var marks in studentsFrom06)
            {
                Console.WriteLine(string.Join(", ", marks));
            }

        }

        private static List<Student> Initialize()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student("Plamen", "Todorov", 20, 123406,"0240895360", 1,"pakito@gmail.com"),
                new Student("Zara", "Tosheva", 18, 123436,  "0244512351",2,"Zara@gmail.com" ),
                new Student("Martin", "Petrov", 25, 123406, "0984089251", 3,"mart0_pi4@abv.bg" ),
                new Student("Slavi", "Kovachev", 55, 123416, "0884083213", 1,"slavi@abv.bg"),
                new Student("Trendafil", "Trendafilov", 23, 163256, "0884011123",2,"fori@gmail.com")
            };

            studentList[0].AddMark(2);
            studentList[0].AddMark(4);
            studentList[1].AddMark(6);
            studentList[1].AddMark(2);
            studentList[2].AddMark(6);
            studentList[2].AddMark(6);
            studentList[3].AddMark(2);
            studentList[3].AddMark(2);
            studentList[4].AddMark(4);
            studentList[4].AddMark(5);

            return studentList;
        }
    }
}
