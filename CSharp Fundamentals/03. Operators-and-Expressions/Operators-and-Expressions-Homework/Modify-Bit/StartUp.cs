using System;

namespace Modify_Bit
{
    public class ModifyBit
    {
        public static void Main()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            byte v = byte.Parse(Console.ReadLine());
            ulong mask = ((ulong)1 << p);
            if (p >= 0 && p < 64)
            {
                if (v == 0)
                {
                    Console.WriteLine(n & ~mask);
                }
                else
                {
                    Console.WriteLine(n | mask);
                }
            }
        }
    }
}
