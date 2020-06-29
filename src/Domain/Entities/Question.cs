using Maturnik.Domain.Common;
using System.Collections.Generic;

namespace Maturnik.Domain.Entities
{
    public class Question : BaseEntity<int>
    {
        public Question(int correctAnswer, string examId, int points = 1)
        {
            this.CorrectAnswer = correctAnswer;
            this.ExamId = examId;
            this.Points = points;

            this.Answers = new HashSet<Answer>();
        }

        public Question(string imgUrl, int correctAnswer, int questionNumber, string examId, bool isSingleAnswer, bool isOpenAnswer, int points = 1)
        {
            this.ImgUrl = imgUrl;
            this.CorrectAnswer = correctAnswer;
            this.ExamId = examId;
            this.Points = points;
            this.QuestionNumber = questionNumber;
            this.IsSingleAnswer = isSingleAnswer;
            this.IsOpenAnswer = isOpenAnswer;

            this.Answers = new HashSet<Answer>();
        }

        public string Title { get; set; }

        public bool IsOpenAnswer { get; set; } = false;

        public int CorrectAnswer { get; set; } // 1 -4 -> 1-a 2-b 3-c 4-d

        public int Points { get; set; }

        public bool IsSingleAnswer { get; set; }

        public int QuestionNumber { get; set; }

        public string ImgUrl { get; set; }

        public string ExamId { get; set; }

        public Exam Exam { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
