
namespace OOP_Principles_Part_1._02.Students_And_Workers
{
    using OOP_Principles_Part_1._02.Students_And_Workers.Humans;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentsAndWorkersTest
    {
        public static void Test()
        {
            Console.WriteLine("\n**********TASK2**********\n");
            var students = InitializeStudents();

            var sortedStudents = from student in students
                                 orderby student.Grade, student.FirstName
                                 select student;

            Console.WriteLine("Students order by grade:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-',30));


            var workers = InitializeWorkers();

            var sortedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ThenBy(worker => worker.FirstName);

            Console.WriteLine("\nWorers sorted by money per hour:");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine(new string('-', 30));

            var merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);

            var sortedMerged = merged.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);

            Console.WriteLine("\nSorted merged students and workers sorted by name:");

            foreach (var human in sortedMerged)
            {
                Console.WriteLine(human);
            }
        }
        private static List<Student> InitializeStudents()
        {
            var students = new List<Student>()
            {
                new Student("Katerina", "Simeonova", 3.5),
                new Student("Darina", "Petrova", 4.8),
                new Student("Stoqn", "Liubenov", 5.5),
                new Student("Cvetan", "Stoichev", 6.0),
                new Student("Emanuela", "Boqnova", 5.45),
                new Student("Traqna", "Hubenova", 5.66),
                new Student("Boqn", "Petkov", 3),
                new Student("Cvetelina", "Stoqnova", 3.88),
                new Student("Toshko", "Vasilev", 4.5),
                new Student("Desislava", "Blagoeva", 4.89)
            };
            return students;
        }
        private static List<Worker> InitializeWorkers()
        {
            var workers = new List<Worker>()
            {
                new Worker("Alexander", "Biserov", 350, 8),
                new Worker("Hari", "Kostov", 400, 8),
                new Worker("Biser", "Lisichkov", 360, 8),
                new Worker("Maria", "Yotova", 365, 8),
                new Worker("Petia", "Tosheva", 550, 8),
                new Worker("Alina", "Nizamova", 100, 8),
                new Worker("Liuba", "Bojkova", 200, 8),
                new Worker("Joro", "Petrov", 210, 8),
                new Worker("Mohammed", "Bhatti", 206, 4),
                new Worker("Coralee", "Crownover", 310, 6)
            };
            return workers;
        }
    }
}
