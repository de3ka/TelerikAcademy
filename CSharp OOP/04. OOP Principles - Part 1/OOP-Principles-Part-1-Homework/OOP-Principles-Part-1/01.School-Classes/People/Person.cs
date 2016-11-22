
namespace OOP_Principles_Part_1._01.School_Classes.People
{
    using System;

    public abstract class Person 
    {
        private string firstName;
        private string familyName;

        public Person(string firstName, string familyName)
        {
            this.FirstName = firstName;
            this.FamilyName = familyName;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty");
                }
                this.firstName = value;
            }
        }
        public string FamilyName
        {
            get
            {
                return this.familyName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty");
                }
                this.familyName = value;
            }
        }
    }
}
