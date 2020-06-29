using Maturnik.Application.Common.Mappings;
using Maturnik.Domain.Entities;

namespace Maturnik.Application.SchoolSubjects.Queries.All
{
    public class SchoolSubjectsViewModel : IMapFrom<SchoolSubject>
    {
        public SchoolSubjectsViewModel()
        {
        }

        public SchoolSubjectsViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
