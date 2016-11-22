
namespace _02.Bank_Accounts.CustomerModels
{
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using _02.Bank_Accounts.Enumerations;
    public class Company: Customer
    {
        public Company(string name)
            : base(name, CustomerType.Company)
        {

        }
    }
}
