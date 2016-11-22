using System;

namespace Enter_Numbers
{
    public class EnterNumbers
    {
        private static string exceptionMessage = "Exception";
        private static int[] Numbers;

        public static void Main()
        {
            var start = 1;
            var end = 100;

            var arrSize = 10 + 2;

            Numbers = new int[arrSize];
            Numbers[0] = start;
            Numbers[Numbers.Length - 1] = end;

            try
            {
                for (int element = 1; element < arrSize - 1; element++)
                {
                    Numbers[element] = int.Parse(Console.ReadLine());
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine(exceptionMessage);
                return;
            }

            for (int element = 1; element < arrSize - 1; element++)
            {
                if (ReadNumber(element - 1, arrSize - 1))
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine(string.Join(" < ", Numbers));
        }

        private static bool ReadNumber(int start, int end)
        {
            try
            {
                if (!(Numbers[start] < Numbers[start + 1] &&
                      Numbers[start + 1] < Numbers[end]))
                {
                    throw new Exception(exceptionMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}