using System;
using System.Collections.Generic;

namespace Extensions_Delegates_Lambda_LINQ._02.IEnumerable_Extension_Methods
{
    public class IEnumerableExtensionsTest
    {
        public static void Test()
        {
            Console.WriteLine("\n**********TASK2**********\n");
            Console.WriteLine("-----IEnumerable extentions-----\n");

            Console.WriteLine("List containing integers:");

            var collection = new List<int>() { 1, -6, 16, 8, 35 };

            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nSum: {0}", collection.Sum());
            Console.WriteLine("Product: {0}", collection.Product());
            Console.WriteLine("Avarage: {0}", collection.Average());
            Console.WriteLine("Max element: {0}", collection.Max());
            Console.WriteLine("Min element: {0}", collection.Min());

            Console.WriteLine("\nArray containing doubles:");

            var array = new double[] { 1.1, -6.36, 16.78, 8.79, 35.9 };

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nSum: {0}", array.Sum());
            Console.WriteLine("Product: {0}", array.Product());
            Console.WriteLine("Avarage: {0}", array.Average());
            Console.WriteLine("Max element: {0}", array.Max());
            Console.WriteLine("Min element: {0}", array.Min());
        }
    }
}
