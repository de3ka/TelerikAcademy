using System;

namespace _05._64_Bit_Array
{
    public class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********TASK5**********\n");

            var bits = new _64BitArray(1234);

            Console.WriteLine("Decimal value:");
            Console.WriteLine("{0}", bits.DecimalValue);
            Console.WriteLine("Value as bits in ulong: ");

            foreach (var item in bits)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            Console.WriteLine();

            var bits2 = new _64BitArray(1024 * 1024 * 1024);

            Console.WriteLine("Bit value:");
            Console.WriteLine("{0}", bits2);
            Console.WriteLine("Bits as decimal value in ulong: ");
            Console.WriteLine(bits2.DecimalValue);
        }
    }
}
