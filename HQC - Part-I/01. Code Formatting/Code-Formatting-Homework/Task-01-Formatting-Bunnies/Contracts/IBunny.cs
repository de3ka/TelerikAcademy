namespace Task_01_Formatting_Bunnies.Contracts
{
    using Enums;

    public interface IBunny
    {
        int Age { get; set; }

        string Name { get; set; }

        FurType FurType { get; set; }

        void Introduce(IWriter writer);
    }
}
