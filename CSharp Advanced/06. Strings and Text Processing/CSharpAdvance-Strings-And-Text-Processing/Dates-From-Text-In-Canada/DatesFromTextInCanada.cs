using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Dates_From_Text_In_Canada
{
    public class DatesFromTextInCanada
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");

            List<DateTime> dates = getDates(input);

            foreach (DateTime currentDate in dates)
            {
                Console.WriteLine("{0:yyyy/MM/dd}", currentDate);
            }
        }

        private static List<DateTime> getDates(string input)
        {
            string pattern = @"\b(?<day>0?\d|1\d|2\d|3[01])\.(?<month>0?\d|1[012])\.(?<year>\d{4})\b";

            MatchCollection match = Regex.Matches(input, pattern);
            List<DateTime> dates = new List<DateTime>();

            foreach (Match item in match)
            {
                dates.Add(new DateTime(Int32.Parse(item.Groups["day"].Value), Int32.Parse(item.Groups["month"].Value), Int32.Parse(item.Groups["year"].Value)));
            }

            return dates;
        }
    }
}
