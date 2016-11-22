using System;
using System.Text.RegularExpressions;

namespace Reverse_Sentence
{
    public class ReverseSentence
    {
        public static void Main()
        {
            string sentence = Console.ReadLine();

            string result = ReverseWordsOrder(sentence);

            Console.WriteLine(result);
        }

        private static string ReverseWordsOrder(string input)
        {
            string pattern = @"[^\s\.;,?!]+";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int startAt = 0;
            string buffer = input;
            int n = matches.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                string word = matches[i].Value;
                buffer = regex.Replace(buffer, word, 1, startAt);
                startAt = buffer.IndexOf(word, startAt) + word.Length;
            }

            return buffer;
        }
    }
}