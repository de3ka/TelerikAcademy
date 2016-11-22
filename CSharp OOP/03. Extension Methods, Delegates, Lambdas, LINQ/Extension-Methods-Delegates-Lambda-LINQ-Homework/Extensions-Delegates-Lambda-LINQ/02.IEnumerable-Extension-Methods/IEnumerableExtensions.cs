using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._02.IEnumerable_Extension_Methods
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {

            dynamic result = 0;

            foreach (var element in collection)
            {
                dynamic number = element;

                result += number;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {

            dynamic result = 1;

            foreach (var element in collection)
            {
                dynamic number = element;
                result *= number;
            }
            return result;
        }

        public static T Average<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {

            dynamic sum = 0;

            foreach (var element in collection)
            {

                dynamic number = element;
                sum += number;
            }

            return sum / collection.Count();
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {

            dynamic result = collection.ElementAt(0);

            foreach (var element in collection)
            {
                dynamic number = element;

                if (number > result)
                {
                    result = number;
                }
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            dynamic result = collection.ElementAt(0);

            foreach (var element in collection)
            {
                dynamic number = element;

                if (number < result)
                {
                    result = number;
                }
            }
            return result;
        }
    }
}
