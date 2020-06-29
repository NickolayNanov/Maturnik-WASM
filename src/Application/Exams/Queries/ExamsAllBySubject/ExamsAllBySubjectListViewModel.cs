using Maturnik.Application.Exams.Queries.ExamsAll;
using System.Collections.Generic;

namespace Maturnik.Application.Exams.Queries.ExamsAllBySubject
{
    public class ExamsAllBySubjectListViewModel
    {
        public ExamsAllBySubjectListViewModel()
        {
            Exams = new HashSet<ExamViewModel>();
        }

        public ExamsAllBySubjectListViewModel(IEnumerable<ExamViewModel> exams)
        {
            Exams = exams;
        }

        public IEnumerable<ExamViewModel> Exams { get; set; }
    }
}
