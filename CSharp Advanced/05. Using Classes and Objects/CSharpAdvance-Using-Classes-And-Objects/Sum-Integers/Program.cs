using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Sum_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            BigInteger result = Sum(numbers);
            Console.WriteLine(result);
        }
        static BigInteger Sum(string numbers)
        {
            string elms = Regex.Replace(numbers, "[^0-9.]", " ");
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            elms = regex.Replace(elms, " ");
            string[] elements = elms.Split(' ');
            BigInteger sum = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                sum += Convert.ToInt64(elements[i]);
            }
            return sum;
        }
    }
}
