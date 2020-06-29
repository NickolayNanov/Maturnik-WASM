using Maturnik.WebUI.Shared.Models;
using MediatR;

namespace Maturnik.Application.Exams.Queries.ExamsAllBySubject
{
    public class ExamsAllBySubjectQuery : IRequest<ApiResponse<ExamsAllBySubjectListViewModel>>
    {
        public ExamsAllBySubjectQuery(string subject)
        {
            ExamTypeUrl = subject;
        }

        public ExamsAllBySubjectQuery()
        {

        }
        
        public string ExamTypeUrl { get; set; }
    }
}
