using System;

namespace ExceptionHandling.Exams
{
    public class CSharpExam : Exam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < CSharpExam.MinScore || value > CSharpExam.MaxScore)
                {
                    throw new ArgumentOutOfRangeException("The exam result must be in range [0, 100]");
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, CSharpExam.MinScore, CSharpExam.MaxScore, "Exam results calculated by score.");
        }
    }
}
