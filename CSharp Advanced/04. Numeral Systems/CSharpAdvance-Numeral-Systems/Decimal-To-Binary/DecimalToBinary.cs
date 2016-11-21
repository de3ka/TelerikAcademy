using System;

namespace Decimal_To_Binary
{
    public class DecimalToBinary
    {
        public static void Main()
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