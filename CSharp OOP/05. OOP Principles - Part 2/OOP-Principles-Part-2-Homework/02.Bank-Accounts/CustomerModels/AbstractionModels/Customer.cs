namespace _02.Bank_Accounts.CustomerModels.AbstractionModels
{
    using _02.Bank_Accounts.Enumerations;
    using System;

    public abstract class Customer
    {
        private string name;

        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }
        public CustomerType CustomerType { get; private set; }
        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of the customer cannot be null or emtpy.");
                }
                this.name=value;
            }
        }
    }
}
