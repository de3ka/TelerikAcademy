using System;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._03_05.Students
{
    public class StudentsTest
    {
        public static void Test()
        {
            var students = StudentArray();

            Console.WriteLine("\n**********TASK3**********\n");
            Console.WriteLine("-----Students whose first name is before its last name alphabetically-----");
            Console.WriteLine("(with a method with LINQ operators)\n");

            var firstResult = FirstBeforeLast(students);

            foreach (var student in firstResult)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine("\n**********TASK4**********\n");
            Console.WriteLine("-----Students in age range 18 - 24 with LINQ-----\n");

            var secondResult = students
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .Select(x => "First Name: " + x.FirstName + " Last Name: " + x.LastName + " Age: " + x.Age);

            foreach (var student in secondResult)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n**********TASK5**********\n");
            Console.WriteLine("-----Sorted decending Lambda-----\n");

            var sortedStudentsLamda = students
                                 .OrderByDescending(st => st.FirstName)
                                 .ThenByDescending(st => st.LastName)
                                 .ToArray();

            foreach (var st in sortedStudentsLamda)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine("\n-----Sorted decending LINQ-----\n");

            var sortedStudentsLINQ = from st in students
                                     orderby st.FirstName descending,
                                     st.LastName descending
                                     select st;

            foreach (var st in sortedStudentsLINQ)
            {
                Console.WriteLine(st);
            }

        }

        private static Student[] StudentArray()
        {
            var students = new Student[10];
            students[0] = new Student("Ivan", "Ivanov", 20);
            students[1] = new Student("Petyr", "Petrovv", 12);
            students[2] = new Student("Georgi", "Georgiev", 30);
            students[3] = new Student("Stoil", "Milanov", 14);
            students[4] = new Student("Stoqn", "Karastoichev", 23);
            students[5] = new Student("Nikolay", "Yankulov", 18);
            students[6] = new Student("Blagoi", "Blagoev", 37);
            students[7] = new Student("Hristo", "Bratanov", 28);
            students[8] = new Student("Dimityr", "Dimitrov", 22);
            students[9] = new Student("Kostandin", "Kostadinov", 20);
            return students;
        }

        private static Student[] FirstBeforeLast(Student[] students)
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0)
                .ToArray();
            return result;
        }
    }
}
