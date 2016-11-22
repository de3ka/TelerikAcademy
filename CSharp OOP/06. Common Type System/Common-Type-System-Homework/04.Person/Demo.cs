using System;

namespace _04.Person
{
    public class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********TASK4**********\n");

            var chovek1 = new Person("Joro", 30);
            var chovek2 = new Person("Liubka");

            Console.WriteLine("{0}\n{1}", chovek1, chovek2);
        }
    }
}
