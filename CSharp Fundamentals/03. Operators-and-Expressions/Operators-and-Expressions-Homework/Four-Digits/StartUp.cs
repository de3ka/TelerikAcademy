using System;

namespace Four_Digits
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int digit1 = num / 1000;
            int digit2 = (num / 100) % 10;
            int digit3 = (num / 10) % 10;
            int digit4 = num % 10;
            int sum = digit1 + digit2 + digit3 + digit4;
            Console.WriteLine("{0}", sum);
            Console.WriteLine("{0}{1}{2}{3}", digit4, digit3, digit2, digit1);
            Console.WriteLine("{0}{1}{2}{3}", digit4, digit1, digit2, digit3);
            Console.WriteLine("{0}{1}{2}{3}", digit1, digit3, digit2, digit4);
        }
    }
}
