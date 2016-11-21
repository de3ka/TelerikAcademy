using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace Date_In_Bulgarian
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int hoursToAdd = 6;
            int minutesToAdd = 30;
            int secondsToAdd = 0;
            string format = "dd.MM.yyyy HH:mm:ss";
            DateTime date1 = DateTime.ParseExact(input, format, null);
            DateTime newDate = date1.Add(new TimeSpan(hoursToAdd, minutesToAdd, secondsToAdd));
            Console.WriteLine(newDate);
            var culture = new System.Globalization.CultureInfo("bg-BG");
            var dayOfWeek = culture.DateTimeFormat.GetDayName(newDate.DayOfWeek);
            Console.WriteLine(dayOfWeek);

        }
    }
}
