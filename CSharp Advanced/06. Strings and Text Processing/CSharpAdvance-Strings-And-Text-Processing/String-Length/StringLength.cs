using System;

namespace String_Length
{
    public class StringLength
    {
        public static void Main()
        {
            const int MaxLength = 20;

            string input = Console.ReadLine();
            if (input.Length > MaxLength)
            {
                input = input.Substring(0, MaxLength);
            }

            if (input.Length < MaxLength)
            {
                input = input.PadRight(MaxLength, '*');
            }

            Console.WriteLine(input);
        }
    }
}