using System;

namespace Problem_04.PrintADeck
{
    public class PrintADeck
    {
        public static void Main()
        {
            string sign = Console.ReadLine();

            int n = 0;
            switch (sign)
            {
                case "J":
                    n = 11;
                    break;
                case "Q":
                    n = 12;
                    break;
                case "K":
                    n = 13;
                    break;
                case "A":
                    n = 14;
                    break;
                default:
                    n = int.Parse(sign);
                    break;
            }

            string[] deck = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            for (int i = 0; i <= n - 2; i++)
            {
                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", deck[i]);
            }
        }
    }
}
