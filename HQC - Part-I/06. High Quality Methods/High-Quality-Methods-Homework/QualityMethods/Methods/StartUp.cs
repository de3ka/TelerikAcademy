using System;
using QualityMethods.Methods.Calculation.Enums;
using QualityMethods.Methods.Calculation.Utils;
using QualityMethods.Methods.Students.Enums;
using QualityMethods.Methods.Students.Models;

namespace QualityMethods.Methods
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(CalculationHelpers.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(CalculationHelpers.DigitToText(5));

            Console.WriteLine(CalculationHelpers.FindMaximumValue(5, -1, 3, 2, 14, 2, 3));

            CalculationHelpers.FormatNumber(1.3, FormatOption.FloatingPoint);
            CalculationHelpers.FormatNumber(0.25, FormatOption.Percent);
            CalculationHelpers.FormatNumber(2.30, FormatOption.AlignRight);

            bool horizontal;
            bool vertical;
            Console.WriteLine(CalculationHelpers.CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine(CalculationHelpers.CheckAlignmentOfLine(3, -1, 3, 2.5));

            Student studentOne = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1980, 05, 01),
                Town = Town.Burgas,
                AdditionalInfo = "N/A"
            };

            Student studentTwo = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova",
                DateOfBirth = new DateTime(1993, 11, 03),
                Town = Town.Plovdiv,
                AdditionalInfo = "N/A"
            };

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                studentOne.FirstName,
                studentTwo.FirstName,
                studentOne.IsOlderThan(studentTwo));
        }
    }
}
