using System;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._06.Divisible_By_7_And_3
{
    public class Demo
    {
        public static void Test()
        {
            var arrayOfNumbers = new int[] { 1, 3, 6, 11, 14, 18, 21, 28, 42 };

            Console.WriteLine("\n**********TASK6**********\n");
            Console.WriteLine("-----Print numbers divisible by 7 & 3 with extension methods & lambda expr-----\n");

            arrayOfNumbers.PrintDivisibleBy7And3();
            
            Console.WriteLine("-----Rewrite the same with LINQ-----\n");

            var filteredArray =
                from num in arrayOfNumbers
                where num % 3 == 0 && num % 7 == 0
                select num;

            foreach (var number in filteredArray)
            {
                Console.WriteLine(number);
            }
        }
    }
}
