using System;

namespace OOP_Principles_Part_1._02.Students_And_Workers.Humans
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal rate;

            if (this.WorkHoursPerDay != 0)
            {
                rate = (decimal)this.weekSalary / this.WorkHoursPerDay;
            }
            else
            {
                rate = 0;
            }

            return rate;
        }

        public override string ToString()
        {
            return string.Format("Worker's Name: {0} {1}\nWorker earns: {2:0.00}lv/h", this.FirstName, this.LastName, MoneyPerHour());
        }
    }
}
