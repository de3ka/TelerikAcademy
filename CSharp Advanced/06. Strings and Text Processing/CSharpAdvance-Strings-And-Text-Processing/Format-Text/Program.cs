using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace Format_Number
{
    class Program
    {
        static void Main(string[] args)
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
