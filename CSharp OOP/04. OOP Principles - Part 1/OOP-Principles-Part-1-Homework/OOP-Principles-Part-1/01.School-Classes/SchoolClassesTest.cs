namespace OOP_Principles_Part_1
{
    using OOP_Principles_Part_1._01.School_Classes.Disciplines;
    using OOP_Principles_Part_1._01.School_Classes.Interfaces;
    using OOP_Principles_Part_1._01.School_Classes.People;
    using OOP_Principles_Part_1._01.School_Classes.SchoolClass;
    using System;
    using System.Collections.Generic;

    class SchoolClassesTest
    {
        public static void Test()
        {
            Console.WriteLine("**********TASK1**********\n");
            Discipline ComputerScience = new Discipline("Computer Science", 20, 2, "Code all day.");
            Discipline Physics = new Discipline("Physics", 10, 2, "Physics makes the world go round.");
            Discipline Mathematics = new Discipline("Mathematics", 30, 3, "2 + 2 = 4");
            Discipline Literature = new Discipline("Literature", 30, 3, "To be or not to be.");
            Discipline English = new Discipline("English", 20, 2, "A is for apple, B is for bee.");


            Teacher ItTeacher = new Teacher("Doncho", "Donchev", "Hello World!");
            Teacher NaturalScienceTeacher = new Teacher("Albert", "Einstein", "E=mc2");
            Teacher LitTeacher = new Teacher("Will", "Shakespeare", "Shake your spear at Shakespeare");

            NaturalScienceTeacher.AddDiscipline(Mathematics);
            NaturalScienceTeacher.AddDiscipline(Physics);
            ItTeacher.AddDiscipline(ComputerScience);
            LitTeacher.AddDiscipline(English);
            LitTeacher.AddDiscipline(Literature);


            Student Pesho = new Student("Petyr", "Nizamov", 1, "Momma's boy");
            Student Mara = new Student("Mariika", "Ivanova", 2, "Pesho's girlfriend");
            Student Ivan = new Student("Vanko", "Marinov", 3, "Teacher's pet");
            Student Joanna = new Student("Joanna", "Petrova", 4, "Prom's queen");
            Student Plamen = new Student("Plamen", "Petrov", 6, "Joanna's twin brother");
            Student Joro = new Student("Joro", "Martinov", 10, "The school's bully");

            SchoolClass FirstGrades = new SchoolClass("1a", "We are firstgraders.");
            SchoolClass Seniors = new SchoolClass("12a", "Final year of school.");

            FirstGrades.AddTeacher(NaturalScienceTeacher);
            FirstGrades.AddTeacher(LitTeacher);
            Seniors.AddTeacher(ItTeacher);
            Seniors.AddTeacher(NaturalScienceTeacher);

            FirstGrades.AddStudent(Pesho);
            FirstGrades.AddStudent(Mara);
            FirstGrades.AddStudent(Ivan);
            Seniors.AddStudent(Joanna);
            Seniors.AddStudent(Plamen);
            Seniors.AddStudent(Joro);

            School PMG = new School();

            PMG.AddClass(FirstGrades);
            PMG.AddClass(Seniors);

            List<IComment> comments = new List<IComment>()
            {
                NaturalScienceTeacher, ItTeacher, LitTeacher, Pesho, Mara, Ivan,Joanna,Plamen,Joro, Physics, Mathematics, Literature, English, FirstGrades, Seniors
            };

            foreach (var obj in comments)
            {
                Console.WriteLine(obj.ToString());
                Console.WriteLine("Personal comment: {0}", obj.Comment);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
