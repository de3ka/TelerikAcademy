using System;

namespace Reverse_String
{
    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] inputToString = input.ToCharArray();

            for (int i = 0; i < inputToString.Length / 2; i++)
            {
                char temp = inputToString[i];
                inputToString[i] = inputToString[inputToString.Length - i - 1];
                inputToString[inputToString.Length - i - 1] = temp;
            }

            string res = new string(inputToString);
            Console.WriteLine(res);
        }
    }
}
