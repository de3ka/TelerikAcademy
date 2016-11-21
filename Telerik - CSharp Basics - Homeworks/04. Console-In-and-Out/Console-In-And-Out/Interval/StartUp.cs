using System;

namespace Interval
{
    public class StartUp
    {
        public static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = num1 + 1; i < num2; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine("{0}", counter);
        }
    }
}
