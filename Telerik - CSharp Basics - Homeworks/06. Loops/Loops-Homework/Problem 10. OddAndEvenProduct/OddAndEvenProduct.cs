using System;
using System.Numerics;

namespace Problem_10.OddAndEvenProduct
{
    public class OddAndEvenProduct
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string nums = Console.ReadLine();
            string[] nums1 = nums.Split(' ');
            BigInteger productOddElements = 1;
            BigInteger productEvenElements = 1;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    productOddElements *= Convert.ToInt32(nums1[i]);
                }
                else
                {
                    productEvenElements *= Convert.ToInt32(nums1[i]);
                }
            }
            if (productEvenElements == productOddElements)
            {
                Console.WriteLine("yes {0}", productOddElements);
            }
            else
            {
                Console.WriteLine("no {0} {1}", productOddElements, productEvenElements);
            }
        }
    }
}