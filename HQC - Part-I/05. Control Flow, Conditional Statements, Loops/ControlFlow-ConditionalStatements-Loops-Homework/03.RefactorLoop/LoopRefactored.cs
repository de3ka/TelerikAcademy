using System;

namespace RefactorLoop
{
    public class LoopRefactored
    {
        internal static void LoopThroughArray(int[] arrayToSearch, int expectedValue)
        {
            var isValueFound = false;
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(arrayToSearch[i]);

                isValueFound = CheckForMatchingValue(i, expectedValue, arrayToSearch[i]);
                if (isValueFound)
                {
                    break;
                }
            }

            if (isValueFound)
            {
                Console.WriteLine("Value found");
            }
        }

        private static bool CheckForMatchingValue(int index, int expectedValue, int arrayValue)
        {
            var isMatchingValueFound = false;
            if (index % 10 == 0 && arrayValue == expectedValue)
            {
                isMatchingValueFound = true;
            }

            return isMatchingValueFound;
        }
    }
}
