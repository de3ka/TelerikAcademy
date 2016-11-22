namespace OOP_Principles_Part_1._01.School_Classes.People
{
    using OOP_Principles_Part_1._01.School_Classes.Disciplines;
    using OOP_Principles_Part_1._01.School_Classes.Interfaces;
    using System.Collections.Generic;

    public class Teacher : Person, IComment
    {
        private List<Discipline> disciplines;

        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.disciplines = new List<Discipline>();
        }

        public Teacher(string firstName, string lastName, string comment)
            : base(firstName, lastName)
        {
            this.Comment = comment;
            this.disciplines = new List<Discipline>();
        }

        public string Comment { get; set; }
        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }
        public override string ToString()
        {
            return string.Format("Teacher Name: {0} {1}\nTeaches Disciplines: {2}", this.FirstName, this.FamilyName, string.Join(", ", this.Disciplines));
        }
       
    }
}
