using QualityMethods.Methods.Calculation.Enums;
using System;
using System.Collections.Generic;

namespace QualityMethods.Methods.Calculation.Utils
{
    internal class CalculationHelpers
    {
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            var isValidTriangle = CheckIfSideLengthsCanComposeAValidTriangle(a, b, c);
            if (!isValidTriangle)
            {
                throw new ArgumentException("Sides are of invalid length.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double areaSqr = halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c);
            double area = Math.Sqrt(areaSqr);
            return area;
        }

        internal static string DigitToText(int number)
        {
            var digitTranslations = new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "sevem" },
                { 8, "eight" },
                { 9, "nine" }
            };

            string result;
            if (digitTranslations.ContainsKey(number))
            {
                result = digitTranslations[number];
            }
            else
            {
                throw new ArgumentException("Number is not a digit.");
            }

            return result;
        }

        internal static int FindMaximumValue(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No elements to evaluate.");
            }

            var maximumValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (maximumValue < elements[i])
                {
                    maximumValue = elements[i];
                }
            }

            return maximumValue;
        }

        internal static void FormatNumber(double number, FormatOption formatOption)
        {
            switch (formatOption)
            {
                case FormatOption.FloatingPoint:
                    Console.WriteLine("{0:F2}", number);
                    break;
                case FormatOption.Percent:
                    if (number < 0)
                    {
                        throw new ArgumentOutOfRangeException("The number must be greater or equal to 0 to convert to %.");
                    }

                    Console.WriteLine("{0:P0}", number);
                    break;
                case FormatOption.AlignRight:
                    Console.WriteLine("{0,8}", number);
                    break;
                default: throw new ArgumentException("Invalid formatting option");
            }
        }

        internal static double CalculateDistance(
        double firstPointCoordinateX,
        double firstPointCoordinateY,
        double secondPointCoordinateX,
        double secondPointCoordinateY,
        out bool isHorizontal,
        out bool isVertical)
        {
            isHorizontal = firstPointCoordinateY == secondPointCoordinateY;
            isVertical = firstPointCoordinateX == secondPointCoordinateX;

            var distanceX = secondPointCoordinateX - firstPointCoordinateX;
            var distanceY = secondPointCoordinateY - firstPointCoordinateY;

            var distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }

        internal static string CheckAlignmentOfLine(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            if (firstPointX.Equals(secondPointX) && firstPointY.Equals(secondPointY))
            {
                throw new ArgumentNullException("The points are on the same position. Hence there is no line.");
            }

            if (firstPointX.Equals(secondPointX))
            {
                return "The line is vertical";
            }
            else if (firstPointY.Equals(secondPointY))
            {
                return "The line is horizontal";
            }
            else
            {
                return "The line is tilted at a degree different than 0 and 90";
            }
        }

        private static bool CheckIfSideLengthsCanComposeAValidTriangle(double sideA, double sideB, double sideC)
        {
            var isSideAValid = sideA < (sideB + sideC);
            var isSideBValid = sideB < (sideA + sideC);
            var isSideCValid = sideC < (sideA + sideB);
            var isValidTriangle = isSideAValid && isSideBValid && isSideCValid;

            return isValidTriangle;
        }
    }
}
