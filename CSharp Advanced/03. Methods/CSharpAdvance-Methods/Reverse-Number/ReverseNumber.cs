using System;

namespace Reverse_Number
{
    public class ReverseNumber
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            string result = PerformReverseNumber(number);

            Console.WriteLine(result);
        }

        private static string PerformReverseNumber(string num)
        {
            char[] charArray = num.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}