using System.Collections.Generic;

namespace Maturnik.WebUI.Shared.Dtos.Exam
{
    public class QuestionDto
    {
        public QuestionDto()
        {

        }

        public QuestionDto(string title, int correctAnswer, int selectedAnswer, int questionNumber, bool isOpenAnswer, bool isSingleAnswer, int numberInExam)
        {
            this.Title = title;
            this.IsOpenAnswer = isOpenAnswer;
            this.CorrectAnswer = correctAnswer;
            this.QuestionNumber = questionNumber;
            this.SelectedAnswer = selectedAnswer;
            this.IsSingleAnswer = isSingleAnswer;
            this.NumberInExam = numberInExam;
        }

        public string Title { get; set; }

        public bool IsOpenAnswer { get; set; }

        public int CorrectAnswer { get; set; }

        public int SelectedAnswer { get; set; }

        public int Points { get; set; }

        public bool IsSingleAnswer { get; set; }

        public int QuestionNumber { get; set; }

        public int NumberInExam { get; set; }

        public string ImgUrl { get; set; }

        public IList<AnswerDto> Answers { get; set; }
    }
}
