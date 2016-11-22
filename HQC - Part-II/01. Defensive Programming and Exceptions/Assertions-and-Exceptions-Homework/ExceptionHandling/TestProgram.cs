using System;
using System.Collections.Generic;
using ExceptionHandling.Utils;
using ExceptionHandling.Exams;
using ExceptionHandling.Students;

namespace ExceptionHandling
{
    public class TestProgram
    {
        public const string TaskSeparator = "\n******************************";

        public static void Main(string[] args)
        {
            var charCollection = "Hello!".ToCharArray();
            var charSubsequence = Utilities.Subsequence(charCollection, 2, 3);
            Console.WriteLine(charSubsequence);

            var numbers = new int[] { -1, 3, 2, 1 };
            var numbersSubsequence = Utilities.Subsequence(numbers, 0, 2);
            Console.WriteLine(string.Join(" ", numbersSubsequence));

            var subsequenceAllNumbers = Utilities.Subsequence(numbers, 0, 4);
            Console.WriteLine(string.Join(" ", subsequenceAllNumbers));

            var emptySubsequenceNumbers = Utilities.Subsequence(numbers, 0, 0);
            Console.Write(string.Join(" ", emptySubsequenceNumbers));

            Console.WriteLine(TaskSeparator);

            Console.WriteLine(Utilities.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utilities.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utilities.ExtractEnding("beer", 4));
            Console.WriteLine(Utilities.ExtractEnding("Hi", 100)); //Throws an exception

            Console.WriteLine(TaskSeparator);
            
            Utilities.CheckPrime(23);
            Utilities.CheckPrime(33);

            Console.WriteLine(TaskSeparator);

            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("John", "Doe", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
