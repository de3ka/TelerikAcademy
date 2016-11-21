using System;
using System.Text;

namespace Isosceles_Triangle
{
    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            String str = "\u00A9";
            Console.WriteLine("   " + str + "   ");
            Console.WriteLine("  " + str + " " + str + "  ");
            Console.WriteLine(" " + str + "   " + str + " ");
            Console.WriteLine(str + " " + str + " " + str + " " + str);
        }
    }
}
