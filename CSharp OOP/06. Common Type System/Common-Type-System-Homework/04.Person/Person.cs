
namespace _04.Person
{
    public class Person
    {
        public string Name { get; private set; }
        public byte? Age { get; private set; }

        public Person(string name, byte? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}", Name, Age == null ? "no info" : Age.ToString());
        }
    }
}
