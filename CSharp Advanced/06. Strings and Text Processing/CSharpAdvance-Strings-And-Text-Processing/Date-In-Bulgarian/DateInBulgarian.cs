using System;

namespace Date_In_Bulgarian
{
    public class DateInBulgarian
    {
        public static void Main()
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
