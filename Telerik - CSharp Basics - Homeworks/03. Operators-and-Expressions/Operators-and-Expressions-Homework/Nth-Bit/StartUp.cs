using System;

namespace Nth_Bit
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            double position = double.Parse(Console.ReadLine());

            if ((number & (int)Math.Pow(2, (position - 1))).Equals((int)Math.Pow(2, (position - 1))))
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
