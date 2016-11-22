using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using _01_03.Student._01.Students.Enumerations;

namespace _01_03.Student._01.Students.StudentsModel
{
    [Serializable]
    public class StudentModel : ICloneable, IComparable<StudentModel>
    {
        private string[] Names;

        public StudentModel(string name, string adress, string phone, string email,
            string ssn, byte course, UniversityType uniType, FacultyType facType, SpecialtyType specType)
        {
            Names = name.Split(' ');
            this.Adress = adress;
            this.Phone = phone;
            this.Email = email;
            this.SSN = ssn;
            this.Course = course;
            this.University = uniType;
            this.Faculty = facType;
            this.Specialty = specType;
        }

        public string FirstName
        {
            get
            {
                return Names[0];
            }
        }

        public string MiddleName
        {
            get
            {
                return Names[1];
            }
        }

        public string LastName
        {
            get
            {
                return Names[2];
            }
        }

        public string WholeName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }

        public string Adress { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public string SSN { get; private set; }

        public byte Course { get; private set; }

        public UniversityType University { get; private set; }

        public FacultyType Faculty { get; private set; }

        public SpecialtyType Specialty { get; private set; }

        public override bool Equals(Object o)
        {
            var student = o as StudentModel;

            if (o == null)
            {
                return false;
            }

            return this.FirstName == student.FirstName &&
                   this.MiddleName == student.MiddleName &&
                   this.LastName == student.LastName &&
                   this.Adress == student.Adress &&
                   this.Course == student.Course &&
                   this.Email == student.Email &&
                   this.Faculty == student.Faculty &&
                   this.Phone == student.Phone &&
                   this.SSN == student.SSN &&
                   this.University == student.University &&
                   this.Specialty == student.Specialty;
        }

        public override string ToString()
        {
            return string.Format("Student:\nStudent's Name: {0}\nStudent's SSN: {1}\nStudent's University: {2}\nStudent's Speciality: {3}\nStudent's Faculty: {4}\nStudent's Course: {5}\nStudent's Adress: {6}\nStudent's Phone: {7}\nStudent's Email: {8}"
                , this.WholeName, this.SSN, this.University, this.Specialty, this.Faculty, this.Course, this.Adress, this.Phone, this.Email);
        }

        public static bool operator ==(StudentModel firstStudent, StudentModel secondStudent)
        {
            return ReferenceEquals(firstStudent, secondStudent) || firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(StudentModel firstStudent, StudentModel secondStudent)
        {
            return !(firstStudent == secondStudent);
        }

        public int CompareTo(StudentModel other)
        {
            int comparison = this.WholeName.CompareTo(other.WholeName);

            if (comparison == 0)
                return this.SSN.CompareTo(other.SSN);

            return comparison;
        }

        public override int GetHashCode()
        {
            int hash = 29;
            int hashMultiplier = 11;

            unchecked
            {

                hash = hash * hashMultiplier + string.Format("{0} {1} {2}", FirstName, MiddleName, LastName).GetHashCode();
                hash = hash * hashMultiplier + Adress.GetHashCode();
                hash = hash * hashMultiplier + Course.GetHashCode();
                hash = hash * hashMultiplier + Email.GetHashCode();
                hash = hash * hashMultiplier + Faculty.GetHashCode();
                hash = hash * hashMultiplier + Phone.GetHashCode();
                hash = hash * hashMultiplier + SSN.GetHashCode();
                hash = hash * hashMultiplier + University.GetHashCode();
                hash = hash * hashMultiplier + Specialty.GetHashCode();
            }

            return hash;
        }

        public object Clone()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);

            stream.Position = 0;
            Object cloned = formatter.Deserialize(stream);
            stream.Close();

            return cloned;
        }
    }
}
