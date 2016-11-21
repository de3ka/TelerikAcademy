using System;

namespace Bit_Exchange
{
    public class StartUp
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            int fakeBitOne = 3;
            int fakeBitTwo = 24;
            if (number >= 0 && number <= 4294967295)
            {
                for (int i = 0; i < 3; i++)
                {
                    long maskOne = (number & (1 << fakeBitOne)) >> fakeBitOne;
                    long maskTwo = (number & (1 << fakeBitTwo)) >> fakeBitTwo;
                    if (maskOne == 0)
                    {
                        number = number & (~(1 << fakeBitTwo));
                    }
                    else if (maskOne == 1)
                    {
                        number = number | (1 << fakeBitTwo);
                    }
                    if (maskTwo == 0)
                    {
                        number = number & (~(1 << fakeBitOne));
                    }
                    else if (maskTwo == 1)
                    {
                        number = number | (1 << fakeBitOne);
                    }

                    fakeBitOne++;
                    fakeBitTwo++;
                }

                Console.WriteLine(number);
            }
            else
            {

            }
        }
    }
}
