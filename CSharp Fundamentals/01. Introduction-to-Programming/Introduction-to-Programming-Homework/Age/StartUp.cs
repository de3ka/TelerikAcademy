using System;

namespace Age
{
    public class StartUp
    {
        public static void Main()
        {
            //please use the following format MM.DD.YYYY
            DateTime userBirthday = DateTime.Parse(Console.ReadLine());
            long result = DateTime.Today.Subtract(userBirthday).Ticks;

            Console.WriteLine(new DateTime(result).Year - 1);
            Console.WriteLine(new DateTime(result).AddYears(10).Year - 1);
        }
    }
}
