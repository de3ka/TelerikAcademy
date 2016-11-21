using System;

namespace _3rd_Bit
{
    public class StartUp
    {
        public static void Main()
        {
            ushort integerNum = ushort.Parse(Console.ReadLine());
            if (integerNum > 0)
            {
                byte position = 3;
                int moveBit = integerNum >> position;
                int bit = moveBit & 1;
                Console.WriteLine("{0}", bit);
            }
            else
            {

            }
        }
    }
}
