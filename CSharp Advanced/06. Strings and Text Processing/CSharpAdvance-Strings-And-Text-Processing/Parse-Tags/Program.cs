using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parse_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = ConvertToUpperCase(text);
            Console.WriteLine(result);
        }
        private static string ConvertToUpperCase(string input)
        {
            string pattern = @"<upcase>(?<content>(.|\s)+?)</upcase>";

            MatchCollection matches = Regex.Matches(input, pattern);

            string result = Regex.Replace(input, pattern, m => m.Groups["content"].Value.ToUpper());

            return result;
        }
    }
}
