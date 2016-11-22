namespace Problem_03.CombinationsWithoutDuplicates
{
    public class StartUp
    {
        public static void Main()
        {
            int elementsCount = 2;
            int setCount = 4;
            CombinationsGenerator.Generate(setCount, new int[elementsCount]);
        }
    }
}