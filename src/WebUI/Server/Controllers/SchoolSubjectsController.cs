using Maturnik.Application.SchoolSubjects.Queries.All;
using Maturnik.WebUI.Shared.Models;
using System.Threading.Tasks;

namespace Maturnik.WebUI.Server.Controllers
{
    public class SchoolSubjectsController : UnauthorizedApiController
    {
        public async Task<ApiResponse<AllSchoolSubjectsViewModel>> List()
        {
            return await Mediator.Send(new AllSchoolSubjectsQuery());
        }
    }
}
