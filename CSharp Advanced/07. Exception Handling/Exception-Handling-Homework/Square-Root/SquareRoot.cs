using System;

namespace Square_Root
{
    public class SquareRoot
    {
        public static void Main()
        {
            var byebye = "Good bye";
            var error = "Invalid number";

            try
            {
                var input = double.Parse(Console.ReadLine());
                var sqrt = Math.Sqrt(input).ToString("F3");

                if (sqrt == "NaN")
                {
                    throw new FormatException();
                }
                else
                {
                    Console.WriteLine(sqrt);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(error);
            }
            finally
            {
                Console.WriteLine(byebye);
            }
        }
    }
}