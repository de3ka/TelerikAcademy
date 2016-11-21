using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_To_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string binary = Console.ReadLine();
            binary.TrimStart('0');

            long decimalNum = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                // we start with the least significant digit, and work our way to the left
                if (binary[binary.Length - i - 1] == '0')
                    continue;
                decimalNum += (long)Math.Pow(2, i);
            }
            Console.WriteLine(decimalNum);

        }
    }
}
