using System;

namespace Null_Values_Arithmetic
{
    public class StartUp
    {
        public static void Main()
        {
            int? integerNull = null;
            Console.WriteLine("\nInteger with null value: ", integerNull);
            double? doubleNull = null;
            Console.WriteLine("\nDouble with null value: ", doubleNull);
            integerNull = 5;
            Console.WriteLine("\nThe real integer number with value 5: " + integerNull);
            doubleNull = 49.7657;
            Console.WriteLine("\nThe real double number with value 49.7657: " + doubleNull);
        }
    }
}
