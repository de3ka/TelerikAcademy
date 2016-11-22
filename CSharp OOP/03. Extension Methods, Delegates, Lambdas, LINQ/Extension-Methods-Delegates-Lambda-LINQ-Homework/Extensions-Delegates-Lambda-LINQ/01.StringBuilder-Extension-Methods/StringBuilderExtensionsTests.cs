using System;
using System.Text;

namespace Extensions_Delegates_Lambda_LINQ._01.StringBuilder_Extension_Methods
{
    public class StringBuilderExtensionsTests
    {
        public static void Test()
        {
            Console.WriteLine("**********TASK1**********\n");
            Console.WriteLine("-----StringBuilder Substring-----\n");

            Console.WriteLine("Test StingBuilder look like:");

            var forSubstring = new StringBuilder();
            forSubstring.Append("This string is only for test.");

            Console.WriteLine(forSubstring.ToString());

            Console.WriteLine("\n---Testing first Substring method---\n(showing substring from specified index to specified length):\n");
            Console.WriteLine("Result: {0}", forSubstring.Substring(5, 6));

            forSubstring.Clear();

            forSubstring.Append("This string is only for test.");

            Console.WriteLine("\n---Testing second Substring method---\n(showing substring from specified index to the end of the string):\n");
            Console.WriteLine("Result: {0}", forSubstring.Substring(5));
        }
    }
}
