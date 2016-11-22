using System;
using System.Collections.Generic;
using OOP_Principles_Part_1._01.School_Classes.Interfaces;
using OOP_Principles_Part_1._01.School_Classes.Constants;

namespace OOP_Principles_Part_1._01.School_Classes.People
{
    public class Student : Person, IComment
    {
        internal static List<int> uniqueClassNumbers = new List<int>();
        private int classNumber;

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string firstName, string lastName, int classNumber, string comment)
            : this(firstName, lastName, classNumber)
        {
            this.Comment = comment;
        }

        public string Comment { get; set; }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            private set
            {

                if (value < GlobalConstants.MIN_CLASS_NUMBER || value > GlobalConstants.MAX_CLASS_NUMBER)
                {
                    throw new ArgumentOutOfRangeException("Class cannot be less than 1 or larger than 12");
                }

                if (Student.uniqueClassNumbers.Contains(value))
                {
                    throw new ArgumentException("This class number already exists!");
                }

                this.classNumber = value;
                Student.uniqueClassNumbers.Add(value);
            }
        }
        public override string ToString()
        {
            return string.Format("Student Name: {0} {1}\nClass Number: {2}", this.FirstName, this.FamilyName, this.ClassNumber);
        }
    }
}
