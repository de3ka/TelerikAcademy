using _02.Bank_Accounts.Enumerations;
using _02.Bank_Accounts.CustomerModels.AbstractionModels;

namespace _02.Bank_Accounts.CustomerModels
{
    public class Company : Customer
    {
        public Company(string name)
            : base(name, CustomerType.Company)
        {
        }
    }
}
