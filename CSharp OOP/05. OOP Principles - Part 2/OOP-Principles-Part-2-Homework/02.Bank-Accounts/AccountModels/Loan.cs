namespace _02.Bank_Accounts.AccountModels
{
    using _02.Bank_Accounts.AccountModels.Abstraction;
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using _02.Bank_Accounts.Enumerations;
    using _02.Bank_Accounts.GlobalConstants;
    using System;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterest(int period)
        {
            decimal result = 0;
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (period <= GlobalConstants.COMPANY_NO_INTEREST_MONTHS)
                {
                    result = 0;
                }
                else
                {
                    result = (period - GlobalConstants.COMPANY_NO_INTEREST_MONTHS) * this.InterestRate;
                }

                return result;
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (period <= GlobalConstants.INDIVIDUAL_NO_INTEREST_MONTHS)
                {
                    result = 0;
                }
                else
                {
                    result = (period - GlobalConstants.INDIVIDUAL_NO_INTEREST_MONTHS) * this.InterestRate;
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
        }
    }
}
