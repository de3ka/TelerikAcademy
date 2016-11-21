using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_To_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            long decimalNum = long.Parse(Console.ReadLine());
            string binaryRepresentation = string.Empty;
            while (decimalNum > 0)
            {
                if (decimalNum % 2 == 1)
                {
                    binaryRepresentation = '1' + binaryRepresentation;
                }
                else
                {
                    binaryRepresentation = '0' + binaryRepresentation;
                }
                decimalNum /= 2;
            }
            Console.WriteLine(binaryRepresentation);
        }
    }
}
