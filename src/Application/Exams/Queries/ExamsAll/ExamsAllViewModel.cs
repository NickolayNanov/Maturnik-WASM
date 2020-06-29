using System.Collections;
using System.Collections.Generic;

namespace Maturnik.Application.Exams.Queries.ExamsAll
{
    public class ExamsAllViewModel
    {
        public ExamsAllViewModel()
        {

        }

        public ExamsAllViewModel(IEnumerable<ExamViewModel> exams)
        {
            Exams = exams;
        }

        public IEnumerable<ExamViewModel> Exams { get; set; }
    }
}
