using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Maturnik.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserExams = new HashSet<UserExam>();
        }

        public ApplicationUser(string email)
        {
            this.Email = email;

            this.UserExams = new HashSet<UserExam>();
        }

        public ICollection<UserExam> UserExams { get; set; }
    }
}
