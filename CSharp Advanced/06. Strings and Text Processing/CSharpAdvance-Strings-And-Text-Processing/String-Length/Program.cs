using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Length
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxLength = 20;

            string input = Console.ReadLine();
            if (input.Length > MaxLength)
            {
                input = input.Substring(0, MaxLength);
            }
            else if (input.Length<MaxLength)
            {
                input = input.PadRight(MaxLength, '*');
            }
            else
            {
                input = input;
            }
            Console.WriteLine(input);
        }
        
    }
}
