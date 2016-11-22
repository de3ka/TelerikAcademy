using System;
using QualityMethods.Methods.Students.Enums;

namespace QualityMethods.Methods.Students.Contracts
{
    /// <summary>
    /// Student class.
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// Student's first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Student's last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Student's date of birth.
        /// </summary>
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Student's hometown.
        /// </summary>
        Town Town { get; set; }

        /// <summary>
        /// Contains some additional info about the student.
        /// </summary>
        string AdditionalInfo { get; set; }
    }
}
