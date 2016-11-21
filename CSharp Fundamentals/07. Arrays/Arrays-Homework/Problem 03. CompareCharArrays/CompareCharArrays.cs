using System;

namespace Problem_03.CompareCharArrays
{
    public class CompareCharArrays
    {
        public static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[i] < second[i])
                {
                    Console.WriteLine("<");
                    return;
                }
                else if (first[i] > second[i])
                {
                    Console.WriteLine(">");
                    return;
                }
            }

            if (first.Length > second.Length)
            {
                Console.WriteLine(">");
            }
            else if (first.Length < second.Length)
            {
                Console.WriteLine("<");
            }
            else
            {
                Console.WriteLine("=");
            }
        }
    }
}
