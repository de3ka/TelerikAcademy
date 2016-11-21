using System;

namespace Problem_03.MinMaxSumAndAverageOfNNumbers
{
    public class MinMaxSumAndAverageOfNNumbers
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            double minNum = double.MaxValue;
            double maxNum = double.MinValue;
            double sum = 0;
            double average = 0;
            for (int i = 0; i < length; i++)
            {
                double num = double.Parse(Console.ReadLine());
                minNum = Math.Min(minNum, num);
                maxNum = Math.Max(maxNum, num);
                sum += num;
                average = sum / length;
            }
            Console.WriteLine("min={0:F2}", minNum);
            Console.WriteLine("max={0:F2}", maxNum);
            Console.WriteLine("sum={0:F2}", sum);
            Console.WriteLine("avg={0:F2}", average);
        }
    }
}