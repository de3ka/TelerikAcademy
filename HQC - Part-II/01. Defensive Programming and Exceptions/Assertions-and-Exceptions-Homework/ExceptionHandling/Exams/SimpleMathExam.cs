using ExceptionHandling.Enums;
using System;

namespace ExceptionHandling.Exams
{
    public class SimpleMathExam : Exam
    {
        private const int MinProblemsSolved = 0;
        private const int MaxProblemsSolved = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < SimpleMathExam.MinProblemsSolved || value > SimpleMathExam.MaxProblemsSolved)
                {
                    throw new ArgumentOutOfRangeException("The problems solved must be in th range [0,10]");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved <= 2)
            {
                return new ExamResult((int)Grades.MinGrade, (int)Grades.MinGrade, (int)Grades.MaxGrade, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved > 2 && this.ProblemsSolved <= 4)
            {
                return new ExamResult((int)Grades.PassGrade, (int)Grades.MinGrade, (int)Grades.MaxGrade, "Average result: you should study harder.");
            }
            else if (this.ProblemsSolved > 4 && this.ProblemsSolved <= 6)
            {
                return new ExamResult((int)Grades.AverageGrade, (int)Grades.MinGrade, (int)Grades.MaxGrade, "Good result: not very bad.");
            }
            else if (this.ProblemsSolved > 6 && this.ProblemsSolved <= 8)
            {
                return new ExamResult((int)Grades.VeryGoodGrade, (int)Grades.MinGrade, (int)Grades.MaxGrade, "Very good result: keep up the good work.");
            }

            return new ExamResult((int)Grades.MaxGrade, (int)Grades.MinGrade, (int)Grades.MaxGrade, "Excellent result: you've done amazing.");
        }
    }
}