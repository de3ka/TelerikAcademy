using System;

namespace Problem_04.MaximalSequence
{
    public class MaximalSequence
    {
        public static void Main()
        {
            uint n = GetArraySize();
            int[] arrayN = GetArray(n);
            int[] maxSequence = GetMaximalSequence(arrayN);
            Console.WriteLine(maxSequence.Length);
        }

        private static uint GetArraySize()
        {
            uint size = 0;
            if (uint.TryParse(Console.ReadLine(), out size))
            {
                return size;
            }
            else
            {
                return 0;
            }
        }

        private static int[] GetArray(uint arraySize)
        {
            int[] newArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if (!(int.TryParse(Console.ReadLine(), out newArray[i])))
                {
                    Console.WriteLine("\nWrong input!\n");
                }
            }
            return newArray;
        }
        private static int[] GetMaximalSequence(int[] array)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int startIndex = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentSequence++;
                }
                else
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startIndex = i - maxSequence + 1;
                    }
                    currentSequence = 1;
                }
                if (i == array.Length - 2)
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startIndex = i - maxSequence + 2;
                    }
                }
            }
            int[] resultArray = new int[maxSequence];
            for (int i = startIndex; i < startIndex + maxSequence; i++)
            {
                resultArray[i - startIndex] = array[i];
            }
            return resultArray;
        }
    }
}