using System;

namespace Problem_02.BonusScore
{
    public class BonusScore
    {
        public static void Main()
        {
            int score = int.Parse(Console.ReadLine());
            if (score >= 1 && score <= 3)
            {
                Console.WriteLine("{0}", (score * 10));
            }
            else if (score >= 4 && score <= 6)
            {
                Console.WriteLine("{0}", (score * 100));
            }
            else if (score >= 7 && score <= 9)
            {
                Console.WriteLine("{0}", (score * 1000));
            }
            else if (score <= 0 || score > 9)
            {
                Console.WriteLine("invalid score");
            }
        }
    }
}
