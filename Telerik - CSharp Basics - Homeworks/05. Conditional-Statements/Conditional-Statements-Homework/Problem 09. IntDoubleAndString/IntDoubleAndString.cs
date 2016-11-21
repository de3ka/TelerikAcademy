using System;

namespace Problem_09.IntDoubleAndString
{
    public class IntDoubleAndString
    {
        public static void Main()
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "integer":
                    int usersInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("{0}", usersInt + 1);
                    break;
                case "real":
                    double usersDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", usersDouble + 1);
                    break;
                case "text":
                    string usersString = Console.ReadLine();
                    Console.WriteLine("{0}*", usersString);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
    }
}
