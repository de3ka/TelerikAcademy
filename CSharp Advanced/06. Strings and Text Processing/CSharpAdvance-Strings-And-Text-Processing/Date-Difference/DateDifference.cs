using System;

namespace Date_Difference
{
    public class DateDifference
    {
        public static void Main()
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            string format = "dd.MM.yyyy";
            DateTime date1 = DateTime.ParseExact(input1, format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(input2, format, System.Globalization.CultureInfo.InvariantCulture);

            DateTime newDate1 = new DateTime(DateTime.Now.Year, date1.Month, date1.Day);
            DateTime newDate2 = new DateTime(DateTime.Now.Year, date2.Month, date2.Day);

            TimeSpan timeSpan = newDate2.Subtract(newDate1);
            Console.WriteLine(timeSpan.Days);
        }
    }
}
