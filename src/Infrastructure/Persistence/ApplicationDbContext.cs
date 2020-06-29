using Maturnik.Application.Common.Interfaces;
using Maturnik.Domain.Common;
using Maturnik.Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Maturnik.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<UserExam> UserExams { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<SchoolSubject> SchoolSubjects { get; set; }

        public DbSet<CustomException> Exceptions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetPrimaryKeys(builder);
            QuestionModelSettings(builder);
            AnswerModelSettings(builder);
            SchoolSubjectModelSettings(builder);
            ExamModelSettings(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private void ExamModelSettings(ModelBuilder builder)
        {
            builder.Entity<Exam>()
                            .Property(x => x.YearOfCreation)
                            .IsRequired();
        }

        private void AnswerModelSettings(ModelBuilder builder)
        {
            builder.Entity<Answer>()
                            .Property(answer => answer.Content)
                            .IsUnicode()
                            .IsRequired();

            builder.Entity<Answer>()
                .HasOne(answer => answer.Question)
                .WithMany(question => question.Answers);
        }

        private void SchoolSubjectModelSettings(ModelBuilder builder)
        {
            builder.Entity<SchoolSubject>()
                            .Property(schoolSubject => schoolSubject.Name)
                            .IsRequired()
                            .IsUnicode();
        }

        private void QuestionModelSettings(ModelBuilder builder)
        {
            builder.Entity<Question>()
                            .Property(question => question.Title)
                            .IsUnicode()
                            .IsRequired();

            builder.Entity<Question>()
                            .HasMany(question => question.Answers)
                            .WithOne(answer => answer.Question);

            builder.Entity<Question>()
                            .HasOne(question => question.Exam)
                            .WithMany(exam => exam.Questions)
                            .HasForeignKey(fk => fk.ExamId);
        }

        private void SetPrimaryKeys(ModelBuilder builder)
        {
            builder.Entity<UserExam>().HasKey(pk => new { pk.ExamId, pk.UserId, pk.SolvedOn });
            builder.Entity<Question>().HasKey(pk => pk.Id);
            builder.Entity<SchoolSubject>().HasKey(pk => pk.Id);
            builder.Entity<Answer>().HasKey(pk => pk.Id);
            builder.Entity<Exam>().HasKey(pk => pk.Id);
            builder.Entity<CustomException>().HasKey(pk => pk.Id);
        }
    }
}
