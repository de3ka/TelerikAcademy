using System;

namespace Problem_11.BinaryToDecimal
{
    public class BinaryToDecimal
    {
        public static void Main()
        {
            string binary = Console.ReadLine();
            int[] binaryNumber = new int[binary.Length];
            long decimalNum = 0;
            long degree = binary.Length - 1;
            for (int i = 0; i < binary.Length; i++)
            {
                char temp = binary[i];
                binaryNumber[i] = Convert.ToInt32(temp.ToString());
                decimalNum += binaryNumber[i] * (long)Math.Pow(2, degree);
                degree--;
            }

            Console.WriteLine(decimalNum);
        }
    }
}
