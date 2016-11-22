using System;

namespace Substring_In_Text
{
    public class SubstringInText
    {
        public static void Main()
        {
            string search = Console.ReadLine();
            string input = Console.ReadLine();

            int count = GetStringOccurrences(input, search);
            Console.WriteLine(count);
        }

        private static int GetStringOccurrences(string input, string value)
        {

            input = input.ToUpper();
            value = value.ToUpper();

            int count = 0;
            int index = input.IndexOf(value, 0);

            while (index != -1)
            {
                count++;
                index = input.IndexOf(value, index + 1);
            }

            return count;
        }
    }
}
