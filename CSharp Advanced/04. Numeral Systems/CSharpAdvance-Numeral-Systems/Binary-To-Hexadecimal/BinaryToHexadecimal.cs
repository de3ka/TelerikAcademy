using System;

namespace Binary_To_Hexadecimal
{
    public class BinaryToHexadecimal
    {
        public static void Main(string[] args)
        {
            string binary = Console.ReadLine().TrimStart('0');
            string hexadecimal = Convert.ToString(Convert.ToInt64(binary, 2), 16);

            Console.WriteLine(hexadecimal.ToUpper());
        }
    }
}
