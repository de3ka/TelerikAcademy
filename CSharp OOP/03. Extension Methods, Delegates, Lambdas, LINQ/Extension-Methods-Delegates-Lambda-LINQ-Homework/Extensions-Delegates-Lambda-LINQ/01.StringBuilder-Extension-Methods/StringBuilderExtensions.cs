using System;
using System.Text;

namespace Extensions_Delegates_Lambda_LINQ._01.StringBuilder_Extension_Methods
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            ValidateData(input, index, length);
            string forAppend = input.ToString().Substring(index, length);
            input.Clear();
            input.Append(forAppend);
            return input;

        }

        public static StringBuilder Substring(this StringBuilder input, int index)
        {
            ValidateData(input, index);
            string forAppend = input.ToString().Substring(index);
            input.Clear();
            input.Append(forAppend);
            return input;
        }

        private static void ValidateData(StringBuilder input, int index, int lenght = 0)
        {
            if (index < 0 || index > input.Length)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }
            if (lenght < 0 || lenght > input.Length - index)
            {
                throw new ArgumentOutOfRangeException("Unacceptable lenght!");
            }
        }
    }
}
