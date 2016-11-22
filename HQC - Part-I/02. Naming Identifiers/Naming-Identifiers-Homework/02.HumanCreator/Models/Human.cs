using HumanCreator.Enums;

namespace HumanCreator.Models
{    
    public class Human
    {
        private Human()
        {
        }

        public GenderType Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public static Human Create(int age)
        {
            var newHuman = new Human();

            newHuman.Age = age;
            if (age % 2 == 0)
            {
                newHuman.Name = "Alpha Male";
                newHuman.Gender = GenderType.Male;
            }
            else
            {
                newHuman.Name = "Mega Chick";
                newHuman.Gender = GenderType.Female;
            }

            return newHuman;
        }
    }
}