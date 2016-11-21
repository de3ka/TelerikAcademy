using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> emails = getEmails(input);
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }
        public static List<string> getEmails(string input)
        {
            string pattern = @"\b\w+[\w\-]*(\.\w+[\w\-]*)*@[a-z0-9]+[a-z0-9-]*(\.[a-z0-9]+[a-z0-9-]*)*(\.[a-z]{2,6})\b";
            List<string> emails = new List<string>();
            MatchCollection m = Regex.Matches(input, pattern);
            foreach (Match item in m)
            {
                emails.Add(item.Value);
            }
            return emails;

        }
    }
}
