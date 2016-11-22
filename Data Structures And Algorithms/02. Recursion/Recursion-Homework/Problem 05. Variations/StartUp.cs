using System.Collections.Generic;

namespace Problem_05.Variations
{
    public class StartUp
    {
        public static void Main()
        {
            VariationsGenerator.Generate(2, new List<string>() { "hi", "a", "b" });
        }
    }
}
