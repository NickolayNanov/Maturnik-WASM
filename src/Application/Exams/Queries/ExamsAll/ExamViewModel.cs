using Maturnik.Application.Common.Mappings;
using Maturnik.Domain.Entities;

namespace Maturnik.Application.Exams.Queries.ExamsAll
{
    public class ExamViewModel : IMapFrom<Exam>
    {
        public ExamViewModel()
        {

        }

        public ExamViewModel(string examType)
        {
            ExamType = examType;
        }

        public ExamViewModel(string examId, string examTypeUrl, string examType, int yearOfCreation)
        {
            ExamId = examId;
            ExamTypeUrl = examTypeUrl;
            ExamType = examType;
            YearOfCreation = yearOfCreation;
        }

        public string ExamId { get; set; }

        public string ExamTypeUrl { get; set; }
        public string ExamType { get; set; }

        public int YearOfCreation { get; set; }
    }
}
