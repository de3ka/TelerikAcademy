namespace Problem_02.CombinationsWithDuplicates
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int elementsCount = 2;
            int setCount = 3;
            CombinationsGenerator.Generate(setCount, new int[elementsCount]);
        }
    }
}