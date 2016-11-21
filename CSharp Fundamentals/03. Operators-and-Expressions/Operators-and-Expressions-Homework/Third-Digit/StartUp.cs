using System;

namespace Third_Digit
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int findDigit = (num / 100) % (10);
            //Boolean isSeven = true;
            if (findDigit == 7)
                Console.WriteLine("true");
            else
                Console.WriteLine("false " + findDigit);
        }
    }
}
