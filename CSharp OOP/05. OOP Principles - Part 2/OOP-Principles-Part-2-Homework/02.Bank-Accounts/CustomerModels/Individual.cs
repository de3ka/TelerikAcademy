
namespace _02.Bank_Accounts.CustomerModels
{
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using _02.Bank_Accounts.Enumerations;
    public class Individual:Customer
    {
        public Individual(string name)
            : base(name, CustomerType.Individual)
        {

        }
    }
}
