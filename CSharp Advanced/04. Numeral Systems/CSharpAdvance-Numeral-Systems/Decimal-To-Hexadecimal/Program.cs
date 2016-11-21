using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_To_Hexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            long decimalNum = long.Parse(Console.ReadLine());
            string hexNum = String.Empty;
            long? ostatyk = null;
            while (decimalNum > 0)
            {
                ostatyk = decimalNum % 16;
                switch (ostatyk)
                {
                    case 10: hexNum = 'A' + hexNum;
                        break;
                    case 11: hexNum = 'B' + hexNum;
                        break;
                    case 12: hexNum = 'C' + hexNum;
                        break;
                    case 13: hexNum = 'D' + hexNum;
                        break;
                    case 14: hexNum = 'E' + hexNum;
                        break;
                    case 15: hexNum = 'F' + hexNum;
                        break;
                    default: hexNum = ostatyk.ToString() + hexNum;
                        break;
                }
                decimalNum /= 16;
            }
            Console.WriteLine(hexNum);
        }
    }
}
