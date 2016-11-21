using System;

namespace Hexadecimal_To_Decimal
{
    public class HexadecimalToDecimal
    {
        public static void Main()
        {
            string hexadecimalNum = Console.ReadLine();
            hexadecimalNum.TrimStart('0');

            int convert = 0;
            long decimalNum = 0;
            long degree = hexadecimalNum.Length - 1;

            for (int i = 0; i < hexadecimalNum.Length; i++)
            {
                switch (hexadecimalNum[i])
                {
                    case 'A':
                        convert = 10;
                        break;
                    case 'B':
                        convert = 11;
                        break;
                    case 'C':
                        convert = 12;
                        break;
                    case 'D':
                        convert = 13;
                        break;
                    case 'E':
                        convert = 14;
                        break;
                    case 'F':
                        convert = 15;
                        break;
                    default:
                        convert = int.Parse(hexadecimalNum[i].ToString());
                        break;
                }

                decimalNum += convert * (long)Math.Pow(16, degree);
                degree--;
            }

            Console.WriteLine(decimalNum);
        }
    }
}