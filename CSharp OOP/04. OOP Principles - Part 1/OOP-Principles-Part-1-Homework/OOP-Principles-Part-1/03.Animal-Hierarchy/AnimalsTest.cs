namespace OOP_Principles_Part_1._03.Animal_Hierarchy
{
    using OOP_Principles_Part_1._03.Animal_Hierarchy.Animals;
    using OOP_Principles_Part_1._03.Animal_Hierarchy.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class AnimalsTest
    {
        public static void Test()
        {
            Console.WriteLine("\n**********TASK3**********\n");
            Cat[] cats = new Cat[]
            {
                new Cat("Pesho", 2, SexType.male),
                new Cat("Rijko", 6, SexType.male),
                new Cat("Bella", 3, SexType.female),
                new Cat("Maca", 1, SexType.female),
                new Cat("Mara", 8, SexType.female),
            };

            Console.WriteLine("Cats:");

            foreach (var cat in cats)
            {
                Console.WriteLine(cat);
            }

            Console.WriteLine("\nAverage age of all cats is: {0}\n", Animal.CalculateAverageAge(cats));
            Console.WriteLine("Dogs:");

            Dog[] dogs = new Dog[]
            {
                new Dog("Roby", 4, SexType.male),
                new Dog("Charlie", 5, SexType.male),
                new Dog("Molly", 3, SexType.female),
                new Dog("Abby", 1, SexType.female),
                new Dog("Sara", 10, SexType.female),
            };

            foreach (var dog in dogs)
            {
                Console.WriteLine(dog);
            }

            Console.WriteLine("\nAverage age of all dogs is: {0}\n", Animal.CalculateAverageAge(dogs));

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Bella", 3),
                new Kitten("Maca", 1),
                new Kitten("Mara", 8),
            };

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Pesho", 2),
                new Tomcat("Rijko", 6),
            };

            var allAnimals = new List<Animal>();

            allAnimals.AddRange(tomcats);
            allAnimals.AddRange(kittens);
            allAnimals.AddRange(dogs);

            Console.WriteLine("Average age of all animals is: " + Animal.CalculateAverageAge(allAnimals));

            var dogsFromAll = from animal in allAnimals
                              where animal.GetType() == typeof(Dog)
                              select animal;

            Console.WriteLine("\nAverage age of all dogs from a list of all animals is :" + Animal.CalculateAverageAge(dogsFromAll));
        }
    }
}
