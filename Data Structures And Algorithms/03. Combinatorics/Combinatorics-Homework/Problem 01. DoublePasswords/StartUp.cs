using System;

namespace Problem_01.DoublePasswords
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            
            var numberOfStars = 0;
            foreach (var symbol in input)
            {
                if (symbol == '*')
                {
                    ++numberOfStars;
                }
            }
            
            long result = 1;
            for (int i = 0; i < numberOfStars; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}