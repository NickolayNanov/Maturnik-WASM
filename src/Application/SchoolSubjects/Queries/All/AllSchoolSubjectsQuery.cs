using Maturnik.WebUI.Shared.Models;
using MediatR;

namespace Maturnik.Application.SchoolSubjects.Queries.All
{
    public class AllSchoolSubjectsQuery : IRequest<ApiResponse<AllSchoolSubjectsViewModel>>
    {
    }
}
