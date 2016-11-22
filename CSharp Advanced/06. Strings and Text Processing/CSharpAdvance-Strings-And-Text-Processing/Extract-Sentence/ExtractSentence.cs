using System;
using System.Linq;

namespace Extract_Sentence
{
    public class ExtractSentence
    {
        public static void Main()
        {
            string wordSearch = Console.ReadLine().Trim();
            string text = Console.ReadLine();

            string[] sentences = text
                .Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            char[] separators = GetNonLetterSymbols(text);

            foreach (string sentence in sentences)
            {
                string[] words = sentence
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (word.Trim() == wordSearch)
                    {
                        Console.Write(sentence.Trim() + ". ");
                        break;
                    }
                }
            }
        }

        private static char[] GetNonLetterSymbols(string input)
        {
            char[] symbols = input
                .Where(ch => !char.IsLetter(ch))
                .Distinct()
                .ToArray();

            return symbols;
        }
    }
}