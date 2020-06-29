using Maturnik.Domain.Common;

namespace Maturnik.Domain.Entities
{
    public class SchoolSubject : BaseEntity<int>
    {
        public SchoolSubject()
        {

        }

        public SchoolSubject(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
