using System;
using System.Diagnostics;
using CompareSimpleMaths.Enums;

namespace CompareSimpleMaths.Utils
{
    public static class PerformanceTester
    {
        private const int Integer = 1;
        private const long LongInteger = 1L;
        private const float FloatNumber = 1.0F;
        private const double DoubleNumber = 1.0;
        private const decimal DecimalNumber = 1.0m;
        private const int OpertaionsCount = 10000000;

        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void OperationTest(Operations operation, DataType dataType)
        {
            dynamic result = 0;

            switch (dataType)
            {
                case DataType.Int:
                    result = Integer;
                    break;
                case DataType.Long:
                    result = LongInteger;
                    break;
                case DataType.Float:
                    result = FloatNumber;
                    break;
                case DataType.Double:
                    result = DoubleNumber;
                    break;
                case DataType.Decimal:
                    result = DecimalNumber;
                    break;
            }

            Stopwatch.Start();

            ///using "Integer" const because "result" is casted to the specific type
            ///so c# explicitly casts the "Integer" const to whatever data type "result" is
            for (int i = 0; i < OpertaionsCount; i++)
            {
                switch (operation)
                {
                    case Operations.Add:
                        result += Integer; 
                        break;
                    case Operations.Subtract:
                        result -= Integer;
                        break;
                    case Operations.Multiply:
                        result *= Integer;
                        break;
                    case Operations.Divide:
                        result /= Integer;
                        break;
                    case Operations.Increment:
                        result++;
                        break;
                    default: throw new InvalidOperationException();
                }
            }

            var elapsedType = Stopwatch.Elapsed;
            Console.WriteLine("Used type: {0}\nElapsed Time for {1} operations: {2}\n", (Enum)dataType, OpertaionsCount, elapsedType);
        }
    }
}
