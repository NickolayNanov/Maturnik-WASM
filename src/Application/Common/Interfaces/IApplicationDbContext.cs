using Maturnik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Maturnik.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Exam> Exams { get; set; }

        DbSet<UserExam> UserExams { get; set; }

        DbSet<Question> Questions { get; set; }

        DbSet<Answer> Answers { get; set; }

        DbSet<SchoolSubject> SchoolSubjects { get; set; }

        DbSet<CustomException> Exceptions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
