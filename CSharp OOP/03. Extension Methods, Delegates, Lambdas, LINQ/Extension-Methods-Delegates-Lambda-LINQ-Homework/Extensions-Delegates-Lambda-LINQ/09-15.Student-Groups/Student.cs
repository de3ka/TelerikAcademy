using System;
using System.Collections.Generic;

namespace Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facNumber;
        private string phoneNumber;
        private string email;
        private int groupNumber;
        private List<int> marks = new List<int>();

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName, int age, int facNumber, string phoneNumber, int groupNumber, string email)
            : this(firstName, lastName, age)
        {
            this.FacNumber = facNumber;
            this.PhoneNumber = phoneNumber;
            this.GroupNumber = groupNumber;
            this.Email = email;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Wrong name validation!");
                }
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
                if (value.Length < 2)
                {
                    throw new ArgumentException("Wrong last name validation!");
                }
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
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The age cannot be less than {0} or more than {1}", 0, 150));
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public int FacNumber
        {
            get
            {
                return this.facNumber;
            }
            private set
            {
                if (value.ToString().Length != 6)
                {
                    throw new ArgumentException("Faculty Number must be with exactly 6 digits!");
                }
                this.facNumber = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Number must be with exactly 10 digits!");
                }
                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (!(value.Contains("@")))
                {
                    throw new ArgumentException("Wrong email validation!");
                }
                this.email = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (value < 1 || value > 4)
                {
                    throw new ArgumentException("Groups are between 1 and 4");
                    ;
                }
                this.groupNumber = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                if (this.marks.Count == 0)
                {
                    throw new ArgumentException("This student haven't marks!");
                }
                return this.marks;
            }
        }

        public void AddMark(int mark)
        {
            this.marks.Add(mark);
        }
    }
}
