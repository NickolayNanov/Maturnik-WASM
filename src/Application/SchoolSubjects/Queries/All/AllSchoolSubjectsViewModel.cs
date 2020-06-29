using System.Collections.Generic;

namespace Maturnik.Application.SchoolSubjects.Queries.All
{
    public class AllSchoolSubjectsViewModel
    {
        public AllSchoolSubjectsViewModel()
        {

        }

        public AllSchoolSubjectsViewModel(List<SchoolSubjectsViewModel> subjects)
        {
            Subjects = subjects;
        }

        public List<SchoolSubjectsViewModel> Subjects { get; set; }
    }
}
