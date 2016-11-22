using System;
using _02.Bank_Accounts.AccountModels.Abstraction;
using _02.Bank_Accounts.CustomerModels.AbstractionModels;
using _02.Bank_Accounts.Enumerations;
using _02.Bank_Accounts.GlobalConstants;
using _02.Bank_Accounts.Interfaces;

namespace _02.Bank_Accounts.AccountModels
{
    public class Deposit : Account, IWithdraw
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int period)
        {
            decimal result = 0;

            if (this.Customer.CustomerType == CustomerType.Individual || this.Customer.CustomerType == CustomerType.Company)
            {
                if (this.Balance >= Constants.MIN_BALANCE && this.Balance < Constants.MAX_BALANCE)
                {
                    result = 0;
                }
                else
                {
                    result = period * this.InterestRate;
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
        }

        public void WithdrawMoney(decimal amountToWithDraw)
        {
            if (this.Balance - amountToWithDraw < 0)
            {
                throw new ArgumentOutOfRangeException("Whithdraw amount must be higher than current account balance");
            }
            else
            {
                this.Balance -= amountToWithDraw;
            }
        }
    }
}
