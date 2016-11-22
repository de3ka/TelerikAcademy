using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions_Delegates_Lambda_LINQ._03_05.Students
{
    public class Student
    {

        private const int MIN_AGE = 0;
        private const int MAX_AGE = 150;
        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                CheckIfStrIsNullOrEmpty(value, "First Name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                CheckIfStrIsNullOrEmpty(value, "Last Name");
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < MIN_AGE || value > MAX_AGE)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The age cannot be less than {0} or more than {1}", MIN_AGE, MAX_AGE));
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("First Name: {0}, Last Name: {1}, Age: {2}", this.FirstName, this.LastName, this.Age);
        }

        private void CheckIfStrIsNullOrEmpty(string strToCheck, string message)
        {
            if (string.IsNullOrEmpty(strToCheck))
            {
                throw new ArgumentNullException(string.Format("The {0} cannot be empty!", message));
            }
        }
    }
}
