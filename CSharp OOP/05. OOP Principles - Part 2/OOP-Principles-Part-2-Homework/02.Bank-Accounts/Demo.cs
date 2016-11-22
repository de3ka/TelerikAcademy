namespace _02.Bank_Accounts
{
    using _02.Bank_Accounts.AccountModels;
    using _02.Bank_Accounts.AccountModels.Abstraction;
    using _02.Bank_Accounts.CustomerModels;
    using _02.Bank_Accounts.CustomerModels.AbstractionModels;
    using System;
    using System.Collections.Generic;

    class Demo
    {
        static void Main(string[] args)
        {
            Customer kaloianSimeonov = new Individual("Kaloian Simeonov");
            Customer trifonPetkanov = new Individual("Trifon Petkanov");
            Customer dianaVasileva = new Individual("Diana Vasileva");
            Customer monikaAtanasova = new Individual("Monika Atanasova");
            Customer cocaCola = new Company("Coca Cola");
            Customer microsoft = new Company("Microsoft");
            Customer apple = new Company("Apple");
            Customer google = new Company("Google");

            Deposit depositKaloianSimeonov = new Deposit(kaloianSimeonov, 800m, 0.05m);
            Deposit depositCocaCola = new Deposit(cocaCola, 5000000m, 0.02m);
            Loan loanDianaVasileva = new Loan(dianaVasileva, -10000m, 0.12m);
            Loan loanGoogle = new Loan(google, -1000000m, 0.08m);
            Mortgage mortageTrifonPetkanov = new Mortgage(trifonPetkanov, -50000m, 0.07m);
            Mortgage mortageMictosoft = new Mortgage(microsoft, -5000000m, 0.06m);

            IList<Account> accounts = new List<Account>();
            accounts.Add(depositKaloianSimeonov);
            accounts.Add(depositCocaCola);
            accounts.Add(loanDianaVasileva);
            accounts.Add(loanGoogle);
            accounts.Add(mortageTrifonPetkanov);
            accounts.Add(mortageMictosoft);

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }

            depositKaloianSimeonov.WithdrawMoney(258.15m);
            Console.WriteLine("\n**********Calculate Interest for next 4 months**********\n");
            foreach (var account in accounts)
            {
                Console.WriteLine("{0}Interest: {1:F2}", account, account.CalculateInterest(4));
                Console.WriteLine(new string('-',30));
            }

            depositKaloianSimeonov.DepositMoney(800m);
            loanDianaVasileva.DepositMoney(600.12m);
            mortageTrifonPetkanov.DepositMoney(1825.12m);
            Console.WriteLine("\n**********Calculate Interest for next 8 months**********\n");
            foreach (var account in accounts)
            {
                Console.WriteLine("{0}Interest: {1:F2}", account, account.CalculateInterest(8));
                Console.WriteLine(new string('-', 30));
            }

            Console.WriteLine("\n**********Calculate Interest for next 20 months**********\n");
            foreach (var account in accounts)
            {
                Console.WriteLine("{0}Interest: {1:F2}", account, account.CalculateInterest(20));
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
