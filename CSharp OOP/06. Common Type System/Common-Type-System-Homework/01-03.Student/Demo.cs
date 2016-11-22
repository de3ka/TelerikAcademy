using System;
using System.Linq;
using _01_03.Student._01.Students.StudentsModel;
using _01_03.Student._01.Students.Enumerations;

namespace _01_03.Student
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            var student1 = new StudentModel("Radka Goshova Toshova", "Kaspichan", "0885044568", "radka@gmail.com", "amthdunnowhut", 2, UniversityType.SofiaUniversity, FacultyType.Mathematics, SpecialtyType.AppliedMathematics);
            var student2 = new StudentModel("Pesho Goranov Todorov", "Zli Dol", "0885044568", "pesho@gmail.com", "smthdunnowhut", 2, UniversityType.UNSS, FacultyType.Economics, SpecialtyType.MicroEconomics);
            var student3 = new StudentModel("Stamat Gospodinov Mitev", "Zverino", "0885044338", "stamat@gmail.com", "smthdunnowhut", 2, UniversityType.TUSofia, FacultyType.IT, SpecialtyType.JavaProgrammer);
            var student4 = new StudentModel("Kostadinka Peeva Draganova", "Seslavci", "0885033568", "kostadinka@gmail.com", "amthdunnowhut", 2, UniversityType.NBU, FacultyType.Law, SpecialtyType.PublicLaw);
            var student5 = new StudentModel("Pesho Goshov Toshov", "Vyrshec", "0885055568", "pesho@gmail.com", "amthdunnowhut", 2, UniversityType.SofiaUniversity, FacultyType.Literature, SpecialtyType.EnglishLiterature);
            var student6 = new StudentModel("Conka Miteva Spasova", "Dupnica", "0887944538", "conka@gmail.com", "amthdunnowhut", 2, UniversityType.TUSofia, FacultyType.IT, SpecialtyType.CSharpProgrammer);

            Console.WriteLine("**********TASK1**********\n");
            Console.WriteLine("---Override GetHashCode()---\n");
            Console.WriteLine("Student's Name: " + student1.WholeName + " HashCode: " + student1.GetHashCode());
            Console.WriteLine("Student's Name: " + student4.WholeName + " HashCode: " + student4.GetHashCode());


            Console.WriteLine("\n---Override Equals()---\n");
            Console.WriteLine("Is " + student1.WholeName + " Equal to " + student2.WholeName + " ?");
            Console.WriteLine(student1.Equals(student2));
            Console.WriteLine("Is " + student5.WholeName + " Equal to " + student6.WholeName + " ?");
            Console.WriteLine(student5.Equals(student6));

            Console.WriteLine("\n---Override == operator---\n");
            Console.WriteLine("Is " + student1.WholeName + " == " + student2.WholeName + " ?");
            Console.WriteLine(student1 == student2);
            Console.WriteLine("Is " + student3.WholeName + " == " + student4.WholeName + " ?");
            Console.WriteLine(student3 == student4);
            Console.WriteLine("Is " + student4.WholeName + " == " + student5.WholeName + " ?");
            Console.WriteLine(student4 == student5);

            Console.WriteLine("\n---Override != operator---\n");
            Console.WriteLine("Is " + student6.WholeName + " != " + student2.WholeName + " ?");
            Console.WriteLine(student6 != student2);
            Console.WriteLine("Is " + student3.WholeName + " != " + student5.WholeName + " ?");
            Console.WriteLine(student3 != student5);

            Console.WriteLine("\n**********TASK2**********\n");
            Console.WriteLine("---Add implementations of the ICloneable interface---\n");

            var student7 = (StudentModel)student6.Clone();

            Console.WriteLine("Cloned Student: ");
            Console.WriteLine(student7.ToString());
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Is " + student7.WholeName + " == " + student6.WholeName + " ?");
            Console.WriteLine(student7 == student6);
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Is " + student7.WholeName + " reference equals to " + student6.WholeName + " ?");
            Console.WriteLine(ReferenceEquals(student7, student6)); // should return false if the clone is working OK

            Console.WriteLine("\n**********TASK3**********");
            Console.WriteLine("Compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order)\n");

            var students = new StudentModel[] { student6, student5, student4, student3, student2, student1 }.OrderBy(x => x).ToArray();

            foreach (var item in students)
            {
                Console.WriteLine(item);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
