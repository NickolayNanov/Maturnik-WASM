using System.Collections.Generic;

namespace Maturnik.WebUI.Shared.Dtos.Exam
{
    public class ExamDto
    {
        public string ExamType { get; set; }

        public int YearOfCreation { get; set; }

        public IList<QuestionDto> Questions { get; set; }

        public IList<AnswerDto> Answers { get; set; }
    }
}
