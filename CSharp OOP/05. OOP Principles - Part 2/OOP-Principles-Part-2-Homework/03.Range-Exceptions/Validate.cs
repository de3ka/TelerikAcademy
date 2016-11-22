namespace _03.Range_Exceptions
{
    using System;

    public static class Validate
    {
        public static bool ValidateDataInRange<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            if (min.CompareTo(value) > 0 || max.CompareTo(value) < 0)
            {
                throw new InvalidRangeException<T>(string.Format(
            "Error:\nThe value [{0}] is out of the range [{1} - {2}]",value,min, max),min, max);
            }
            else
            {
                return true;
            }
            throw new NotImplementedException();
        }
    }
}
