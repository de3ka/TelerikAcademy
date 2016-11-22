using OOP_Principles_Part_1._03.Animal_Hierarchy.Enumerations;

namespace OOP_Principles_Part_1._03.Animal_Hierarchy.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, SexType.male)
        {
        }
    }
}
