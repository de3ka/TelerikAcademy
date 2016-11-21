using System;

namespace Problem_12.IndexOfLetters
{
    public class IndexOfLetters
    {
        public static void Main()
        {
            char[] arr = new char['z' - 'a' + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (char)('a' + i);
            }
            string s = Console.ReadLine();

            foreach (char c in s)
            {
                Console.WriteLine(c - 'a');
            }
        }
    }
}
