﻿namespace _02.Bank_Accounts.AccountModels
{
    using _02.Bank_Accounts.AccountModels.Abstraction;
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using _02.Bank_Accounts.GlobalConstants;
    using _02.Bank_Accounts.Enumerations;
    using System;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }
        public override decimal CalculateInterest(int period)
        {
            decimal result = 0;
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (period <= GlobalConstants.INDIVIDUAL_ZERO_INTEREST_MONTHS)
                {
                    result = period * (this.InterestRate / 2);
                }
                else
                {
                    result = (period - GlobalConstants.INDIVIDUAL_ZERO_INTEREST_MONTHS) * this.InterestRate;
                }
                return result;
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (period <= GlobalConstants.COMPANY_HALF_INTEREST_MONTHS)
                {
                    result = period * (this.InterestRate / 2);
                }
                else
                {
                    result = GlobalConstants.COMPANY_HALF_INTEREST_MONTHS * (this.InterestRate / 2);
                    period -= 12;
                    result += period * this.InterestRate;
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