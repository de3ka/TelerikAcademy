using System;
using System.Text.RegularExpressions;

namespace Forbidden_Words
{
    public class ForbiddenWords
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string inputWords = Console.ReadLine();

            string[] forbiddenWords = inputWords.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in forbiddenWords)
            {
                input = ReplaceForbiddenWord(input, word);
            }

            Console.WriteLine(input);
        }

        private static string ReplaceForbiddenWord(string input, string word)
        {
            string pattern = String.Format(@"\b{0}\b", word);
            string result = Regex.Replace(input, pattern, new String('*', word.Length));

            return result;
        }
    }
}
