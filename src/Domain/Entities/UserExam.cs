using Maturnik.Domain.Enums;
using System;

namespace Maturnik.Domain.Entities
{
    public class UserExam
    {
        public UserExam()
        {
            this.SolvedOn = DateTime.Now;
        }

        public UserExam(string userId, string examId, DateTime solvedOn, int points, double grade, string wrongAnswers)
        {
            this.UserId = userId;
            this.ExamId = examId;
            this.SolvedOn = solvedOn;
            this.Points = points;
            this.Grade = grade;
            this.WrongAnswerIds = wrongAnswers;
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string ExamId { get; set; }

        public ExamType ExamType { get; set; }

        public Exam Exam { get; set; }

        public double Grade { get; set; }

        public int Points { get; set; }

        public DateTime SolvedOn { get; set; }

        public string WrongAnswerIds { get; set; }

        public int MaxPoints { get; set; }
    }
}
