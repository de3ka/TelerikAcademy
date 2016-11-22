using System;

namespace _03.Range_Exceptions
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----Testing Custom Exception with DateTime-----\n");

            var minLimit = DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", null);
            var maxLimit = DateTime.ParseExact("31-12-2013", "dd-MM-yyyy", null);

            var exception = new InvalidRangeException<DateTime>("unsuccessful",
                    DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", null),
                    DateTime.ParseExact("31-12-2013", "dd-MM-yyyy", null));

            var test = DateTime.Parse("1.1.1975");

            try
            {
                Validate.ValidateDataInRange(test, minLimit, maxLimit);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n-----Testing Custom Exception with int-----\n");

            int newMinLimit = 100;
            int newMaxLimit = 1000;

            var exceptionOne = new InvalidRangeException<int>("unsuccessful",
                    newMinLimit, newMaxLimit);

            var newTest = 5;

            try
            {
                Validate.ValidateDataInRange(newTest, newMinLimit, newMaxLimit);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
