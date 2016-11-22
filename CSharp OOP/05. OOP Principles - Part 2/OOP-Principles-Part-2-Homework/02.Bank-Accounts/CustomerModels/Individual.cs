using _02.Bank_Accounts.Enumerations;
using _02.Bank_Accounts.CustomerModels.AbstractionModels;

namespace _02.Bank_Accounts.CustomerModels
{
    public class Individual : Customer
    {
        public Individual(string name)
            : base(name, CustomerType.Individual)
        {
        }
    }
}
