using System;
using CompareAdvancedMaths.Enums;
using CompareAdvancedMaths.Utils;

namespace CompareAdvancedMaths
{
    public class FunctionsTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Square root\n-------------------");
            PerformanceTester.OperationTest(Functions.Sqrt, DataType.Float);
            PerformanceTester.OperationTest(Functions.Sqrt, DataType.Double);
            PerformanceTester.OperationTest(Functions.Sqrt, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Natural logarithm\n-------------------");
            PerformanceTester.OperationTest(Functions.Log, DataType.Float);
            PerformanceTester.OperationTest(Functions.Log, DataType.Double);
            PerformanceTester.OperationTest(Functions.Log, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Sinus\n-------------------");
            PerformanceTester.OperationTest(Functions.Sin, DataType.Float);
            PerformanceTester.OperationTest(Functions.Sin, DataType.Double);
            PerformanceTester.OperationTest(Functions.Sin, DataType.Decimal);
            Console.WriteLine();
        }
    }
}
