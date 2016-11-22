using System;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._17.Longest_String
{
    public class LongestStringTest
    {
        public static void Test()
        {
            Console.WriteLine("\n**********TASK17**********\n");
            Console.WriteLine("-----String array looks like this-----\n");
            var stringArr = new string[]{ "random", "strings", "are",
                                         "so", "cool","that", "I", "wanna", "die"};

            foreach (var elem in stringArr)
            {
                Console.Write(elem + " ");
            }

            string longest = stringArr.OrderByDescending(s => s.Length).First();

            Console.WriteLine("\n\nLongest string is: " + longest);
        }
    }
}
