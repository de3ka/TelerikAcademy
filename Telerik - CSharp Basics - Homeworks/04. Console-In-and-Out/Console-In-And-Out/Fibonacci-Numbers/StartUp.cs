using System;
using System.Numerics;

namespace Fibonacci_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            int lengthOfSeries = int.Parse(Console.ReadLine());

            BigInteger firstMember = 0;
            BigInteger secondMember = 1;

            if (lengthOfSeries == 1)
            {
                Console.WriteLine("{0}, ", firstMember);
            }

            else
            {
                BigInteger nextMember = firstMember + secondMember;
                if (lengthOfSeries == 2)
                {
                    Console.Write("{0}, {1} ", firstMember, secondMember);
                }
                else
                {
                    Console.Write("{0}, {1}, ", firstMember, secondMember);
                }
                for (int i = 3; i <= lengthOfSeries; i++)
                {
                    if (i == lengthOfSeries)
                    {
                        Console.Write("{0}", nextMember);
                    }
                    else
                    {
                        Console.Write("{0}, ", nextMember);
                    }

                    BigInteger intermediate = nextMember;
                    nextMember += secondMember;
                    secondMember = intermediate;
                }

            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
