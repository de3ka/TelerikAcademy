using System;

namespace Employee_Data
{
    public class StartUp
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string LastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            string IdNumber = Console.ReadLine();
            uint empNumber = uint.Parse(Console.ReadLine());
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", firstName, LastName, age, sex, IdNumber, empNumber);
        }
    }
}
