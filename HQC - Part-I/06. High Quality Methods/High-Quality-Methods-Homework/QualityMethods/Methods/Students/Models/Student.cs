using System;
using QualityMethods.Methods.Students.Contracts;
using QualityMethods.Methods.Students.Enums;
using QualityMethods.Methods.Students.GlobalConstants;

namespace QualityMethods.Methods.Students.Models
{
    /// <summary>
    /// Class for creating object of type Student. Contains first name, last name, birth date and some other info.
    /// </summary>
    public class Student : IStudent
    {
        private string firstName;

        private string lastName;

        private DateTime dateOfBirth;

        private string additionalInfo;

        public Student()
        {
        }

        /// <summary>
        /// Constructor for Student class
        /// </summary>
        /// <param name="firstName">Student's first name</param>
        /// <param name="lastName">Student's last name</param>
        /// <param name="birthday">Student's birth date</param>
        /// <param name="town">Student's home town</param>
        /// <param name="additionalInfo">Other unspecified info about the student</param>
        public Student(string firstName, string lastName, DateTime birthday, Town town, string additionalInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = birthday;
            this.Town = town;
            this.AdditionalInfo = additionalInfo;
        }

        /// <summary>
        /// Student's first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Constants.IsNullOrEmptyError, "FirstName"));
                }

                this.firstName = value;
            }
        }

        /// <summary>
        /// Student's last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Constants.IsNullOrEmptyError, "LastName"));
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Student's date of birth.
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (IsValidDateOfBirth(value, DateTime.Today))
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DateOfBirth");
                }
            }
        }

        /// <summary>
        /// Student's hometown.
        /// </summary>
        public Town Town { get; set; }

        /// <summary>
        /// Some additional info about the student.
        /// </summary>
        public string AdditionalInfo
        {
            get
            {
                return this.additionalInfo;
            }

            set
            {
                this.additionalInfo = value == null ? "" : value;
            }
        }

        /// <summary>
        /// Compare two students according to their birthdays.
        /// </summary>
        /// <param name="student">The student to be compared to</param>
        /// <returns>Returns true if the current instance of the student is older.</returns>
        public bool IsOlderThan(Student other)
        {
            return this.dateOfBirth < other.dateOfBirth;
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth, DateTime now)
        {
            int age = now.Year - dateOfBirth.Year;

            if (now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            if (Constants.MinimumStudentAge <= age && age <= Constants.MaximumStudentAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}