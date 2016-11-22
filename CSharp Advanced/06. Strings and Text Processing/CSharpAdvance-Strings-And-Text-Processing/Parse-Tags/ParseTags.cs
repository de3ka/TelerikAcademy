using System;
using System.Linq;
using System.Text;

namespace Parse_Tags
{
    public class ParseTags
    {
        public static void Main()
        {
            var openTag = "upcase";
            var closeTag = "/upcase";

            var toParse = Console
                .ReadLine()
                .Split(new char[] { '<', '>' })
                .ToArray();

            var output = new StringBuilder();
            var toUpper = false;

            foreach (var word in toParse)
            {
                if (word == openTag)
                {
                    toUpper = true;
                    continue;
                }

                if (word == closeTag)
                {
                    toUpper = false;
                    continue;
                }

                if (toUpper)
                {
                    output.Append(word.ToUpper());
                }
                else
                {
                    output.Append(word);
                }
            }

            Console.WriteLine(output);
        }
    }
}