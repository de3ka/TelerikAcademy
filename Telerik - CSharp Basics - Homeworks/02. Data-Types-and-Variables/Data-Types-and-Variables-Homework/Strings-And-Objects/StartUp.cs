using System;

namespace Strings_And_Objects
{
    public class StartUp
    {
        public static void Main()
        {
            String str1 = "Hello";
            String str2 = "World";
            Object str3 = str1 + " " + str2;
            Console.WriteLine(str3);
            String str4 = (String)str3;
            Console.WriteLine(str4);
        }
    }
}
