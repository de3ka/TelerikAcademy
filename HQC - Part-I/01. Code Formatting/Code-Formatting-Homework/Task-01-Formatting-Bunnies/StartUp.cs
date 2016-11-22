namespace Task_01_Formatting_Bunnies
{
    using System.Collections.Generic;
    using System.IO;
    using Enums;
    using Models;
    using Utils;

    public class StartUp
    {
        private const string BunniesFilePath = @"..\..\bunnies.txt";

        public static void Main(string[] args)
        {
            var bunnies = new List<Bunny>
            {
                new Bunny
                {
                    Name = "Leonid",
                    Age = 1,
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Name = "Rasputin",
                    Age = 2,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Tiberii",
                    Age = 3,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Neron",
                    Age = 1,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Klavdii",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Vespasian",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Domician",
                    Age = 4,
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Name = "Tit",
                    Age = 2,
                    FurType = FurType.FluffyToTheLimit
                }
            };

            var consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var fileStream = File.Create(BunniesFilePath);
            fileStream.Close();

            using (var streamWriter = new StreamWriter(BunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}
