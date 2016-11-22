using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandling.Validation
{
    public static class Validator
    {
        public static void IsStringNull(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("The {0} cannot be null or empty", name);
            }
        }

        public static void IsArrayNullOrEmpty<T>(IEnumerable<T> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("The array cannot be null");
            }

            if (value.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The array is empty");
            }
        }

        public static void ValidateIfNonNegativeNumber(int number, string name)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} must not be a negative number", name));
            }
        }
    }
}
