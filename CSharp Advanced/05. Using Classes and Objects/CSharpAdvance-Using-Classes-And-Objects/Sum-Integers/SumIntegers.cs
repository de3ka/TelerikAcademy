using System;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Sum_Integers
{
    public class SumIntegers
    {
        public static void Main()
        {
            string numbers = Console.ReadLine();
            BigInteger result = Sum(numbers);
            Console.WriteLine(result);
        }

        private static BigInteger Sum(string numbers)
        {
            string inputElements = Regex.Replace(numbers, "[^0-9.]", " ");
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            inputElements = regex.Replace(inputElements, " ");
            string[] elements = inputElements.Split(' ');

            BigInteger sum = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                sum += Convert.ToInt64(elements[i]);
            }

            return sum;
        }
    }
}
