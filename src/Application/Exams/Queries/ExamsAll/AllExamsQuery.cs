using Maturnik.WebUI.Shared.Models;
using MediatR;

namespace Maturnik.Application.Exams.Queries.ExamsAll
{
    public class AllExamsQuery : IRequest<ApiResponse<ExamsAllViewModel>>
    {
    }
}
