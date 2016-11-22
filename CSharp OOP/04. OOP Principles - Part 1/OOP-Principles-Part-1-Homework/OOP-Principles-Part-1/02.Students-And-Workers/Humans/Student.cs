﻿namespace OOP_Principles_Part_1._02.Students_And_Workers.Humans
{
    using System;
    using OOP_Principles_Part_1._02.Students_And_Workers.Constants;

    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get { return this.grade; }
            set
            {
                if (value < Constants.MIN_GRADE || value > Constants.MAX_GRADE)
                {
                    throw new ArgumentOutOfRangeException(String.Format("Grade must be between {0} and {1}!",Constants.MIN_GRADE, Constants.MAX_GRADE));
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Student's Name:{0} {1}\n Student's Grade: {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}