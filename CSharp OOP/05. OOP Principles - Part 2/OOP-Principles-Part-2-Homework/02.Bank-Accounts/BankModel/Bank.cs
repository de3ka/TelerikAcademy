﻿namespace _02.Bank_Accounts.BankModel
{
    using _02.Bank_Accounts.AccountModels.Abstraction;
    using System.Collections.Generic;

    public class Bank
    {
        private string name;
        private List<Account> accounts;

        public Bank()
        {
            this.accounts = new List<Account>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public List<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
            private set
            {
                this.accounts = value;
            }
        }
    }
}