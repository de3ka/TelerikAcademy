using System;

namespace Print_The_ASCII_Table
{
    public class StartUp
    {
        public static void Main()
        {
            for (int i = 33; i <= 126; i++)
            {
                Console.Write((char)i);
            }
            Console.WriteLine();
        }
    }
}