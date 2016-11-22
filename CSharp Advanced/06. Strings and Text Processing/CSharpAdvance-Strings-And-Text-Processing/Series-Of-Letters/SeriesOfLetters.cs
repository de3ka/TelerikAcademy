using System;
using System.Text;

namespace Series_Of_Letters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var output = new StringBuilder();

            output.Append(input[0]);

            foreach (var letter in input)
            {
                var previousLetter = output[output.Length - 1];

                if (!char.IsLetter(letter))
                {
                    continue;
                }

                if (letter == previousLetter)
                {
                    continue;
                }
                else
                {
                    output.Append(letter);
                }
            }

            Console.WriteLine(output);
        }
    }
}