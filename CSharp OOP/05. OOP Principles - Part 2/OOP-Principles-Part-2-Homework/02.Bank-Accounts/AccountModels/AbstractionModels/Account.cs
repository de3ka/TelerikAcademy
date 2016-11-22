namespace _02.Bank_Accounts.AccountModels.Abstraction
{
    using _02.Bank_Accounts.Enumerations;
    using System;
    using System.Reflection;
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using _02.Bank_Accounts.Interfaces;
    public abstract class Account:IDeposit
    {
        private decimal interestRate;
        public Account(Customer customer, decimal balance, decimal rate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = rate;
        }
        public Customer Customer { get; protected set; }
        public decimal Balance { get; set; }
        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be positive or 0");
                }
                this.interestRate = value;
            }
        }
        public void DepositMoney(decimal amountToDeposit)
        {
            this.Balance += amountToDeposit;
        }
        public abstract decimal CalculateInterest(int period);
        public override string ToString()
        {
            return string.Format("Customer Name: {0}\nCustomer's Balance: {1:F2}\nAccount Type: {2}\nInterest Rate: {3:P1}\n", this.Customer.Name, this.Balance,this.GetType().Name, this.InterestRate);
        }
    }
}
