using Maturnik.Domain.Common;
using Maturnik.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Maturnik.Domain.Entities
{
    public class Exam : BaseEntity<string>
    {
        public Exam()
        {
            Id = Guid.NewGuid().ToString();
            this.ExamUsers = new HashSet<UserExam>();
            this.Questions = new List<Question>();
        }

        public Exam(ExamType type, int yearOfCreation) : base()
        {
            Id = Guid.NewGuid().ToString();
            this.ExamType = type;
            this.YearOfCreation = yearOfCreation;
        }

        public ExamType ExamType { get; set; }

        public int YearOfCreation { get; set; }

        public ICollection<UserExam> ExamUsers { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
