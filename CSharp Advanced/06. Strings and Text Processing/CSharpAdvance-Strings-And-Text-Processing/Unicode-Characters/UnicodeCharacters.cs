using System;
using System.Globalization;
using System.Text;

namespace Unicode_Characters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var unicodeFormat = @"\u{0}";

            var inputStr = Console.ReadLine();

            var charEnum = StringInfo.GetTextElementEnumerator(inputStr);

            var output = new StringBuilder();

            while (charEnum.MoveNext())
            {
                output.Append(string.Format(unicodeFormat, ((int)charEnum.Current.ToString()[0]).ToString("X4")));
            }

            Console.WriteLine(output);
        }
    }
}