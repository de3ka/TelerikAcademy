using System;

namespace Say_Hello
{
    public class SayHello
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PerformSayHello(name);
        }

        private static void PerformSayHello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}

