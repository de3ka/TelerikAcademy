using System;

namespace Odd_Or_Even
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num >= -30 || num <= 30)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine("even " + num);
                }
                else
                {
                    Console.WriteLine("odd " + num);
                }
            }
            else
            {
                Console.WriteLine("Not a valid number.");
            }
        }
    }
}
