using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string> emails = GetEmails(input);

            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }

        private static List<string> GetEmails(string input)
        {
            string pattern = @"\b\w+[\w\-]*(\.\w+[\w\-]*)*@[a-z0-9]+[a-z0-9-]*(\.[a-z0-9]+[a-z0-9-]*)*(\.[a-z]{2,6})\b";
            List<string> emails = new List<string>();
            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match item in match)
            {
                emails.Add(item.Value);
            }

            return emails;
        }
    }
}
