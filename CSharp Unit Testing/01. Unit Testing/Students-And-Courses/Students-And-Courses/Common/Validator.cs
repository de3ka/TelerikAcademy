using System;

namespace Students_And_Courses.Common
{
    public static class Validator
    {
        public static void CheckIfNull<T>(T value, string variableName = "Value")
        {
            if (value == null)
            {
                throw new ArgumentNullException(variableName + " is null.");
            }
        }

        public static void CheckIfEmptyStringOrNull(string value, string variableName = "Value")
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(variableName + " is either empty or null.");
            }
        }

        public static void CheckIfValueInRange(int value, int min, int max, string variableName = "Value")
        {
            if (value < min || value > max)
            {
                var msg = string.Format("{0} is not in given range {1} - {2}.", variableName, min, max);
                throw new ArgumentOutOfRangeException(msg);
            }
        }
    }
}