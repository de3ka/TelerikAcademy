using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string result = reverseNumber(number);
            Console.WriteLine(result);
        }
        static string reverseNumber(string num)
        {
            char[] charArray = num.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
