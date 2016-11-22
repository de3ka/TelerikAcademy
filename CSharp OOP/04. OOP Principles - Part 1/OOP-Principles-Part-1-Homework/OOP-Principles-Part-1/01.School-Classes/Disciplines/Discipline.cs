using OOP_Principles_Part_1._01.School_Classes.Interfaces;
using OOP_Principles_Part_1._01.School_Classes.Constants;
using System;

namespace OOP_Principles_Part_1._01.School_Classes.Disciplines
{
    public class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises, string comment)
            : this(name, numberOfLectures, numberOfExercises)
        {
            this.Comment = comment;
        }

        public string Comment { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Discipline should have name!");
                }
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value < GlobalConstants.DEAFAULT_NUMBER_OF_LECTURES)
                {
                    throw new ArgumentOutOfRangeException("Discipline has to have non negative lectures!");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                if (value < GlobalConstants.DEAFAULT_NUMBER_OF_EXERCISES)
                {
                    throw new ArgumentOutOfRangeException("Discipline has to have non negative exercises!");
                }
                this.numberOfExercises = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}
