namespace Problem_11.PermutationsWithRepetitions
{
    public class StartUp
    {
        public static void Main()
        {
            var set = new int[] { 1, 3, 5, 5 };

            PermutationsGenerator.Generate(set);

            var set2 = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            PermutationsGenerator.Generate(set2);
        }
    }
}