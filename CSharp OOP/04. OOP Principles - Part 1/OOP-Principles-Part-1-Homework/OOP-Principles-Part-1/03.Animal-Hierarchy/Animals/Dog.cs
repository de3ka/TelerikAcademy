using System;
using OOP_Principles_Part_1._03.Animal_Hierarchy.Enumerations;

namespace OOP_Principles_Part_1._03.Animal_Hierarchy.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau bau");
        }
    }
}
