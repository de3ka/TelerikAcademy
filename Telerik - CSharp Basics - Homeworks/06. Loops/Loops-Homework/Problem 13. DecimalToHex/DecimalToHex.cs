using System;

namespace Problem_13.DecimalToHex
{
    public class DecimalToHex
    {
        public static void Main()
        {
            long decimalNum = long.Parse(Console.ReadLine());
            string hexNum = string.Empty;
            long? remainder = null;
            while (decimalNum > 0)
            {
                remainder = decimalNum % 16;
                switch (remainder)
                {
                    case 10:
                        hexNum = 'A' + hexNum;
                        break;
                    case 11:
                        hexNum = 'B' + hexNum;
                        break;
                    case 12:
                        hexNum = 'C' + hexNum;
                        break;
                    case 13:
                        hexNum = 'D' + hexNum;
                        break;
                    case 14:
                        hexNum = 'E' + hexNum;
                        break;
                    case 15:
                        hexNum = 'F' + hexNum;
                        break;
                    default:
                        hexNum = remainder.ToString() + hexNum;
                        break;
                }
                decimalNum /= 16;
            }

            Console.WriteLine(hexNum);
        }
    }
}
