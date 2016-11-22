using System;
using System.Globalization;
using System.Threading;

namespace Format_Number
{
    public class FormatNumber
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            string input = Console.ReadLine();
            int number = Int32.Parse(input);

            Console.WriteLine("{0, 15:D}", number);
            Console.WriteLine("{0,15:X4}", number);
            Console.WriteLine("{0,15:P2}", number);
            Console.WriteLine("{0,15:E2}", number);
        }
    }
}
