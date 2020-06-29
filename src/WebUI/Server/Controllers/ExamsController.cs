using Maturnik.Application.Exams.Queries.ExamsAll;
using Maturnik.Application.Exams.Queries.ExamsAllBySubject;
using Maturnik.WebUI.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Maturnik.WebUI.Server.Controllers
{
    [Authorize]
    public class ExamsController : ApiController
    {
        [HttpGet]
        public async Task<ApiResponse<ExamsAllViewModel>> All()
        {
            return await Mediator.Send(new AllExamsQuery());
        }

        [HttpGet]
        public async Task<ApiResponse<ExamsAllBySubjectListViewModel>> AllBySubject(string subject)
        {
            return await Mediator.Send(new ExamsAllBySubjectQuery(subject));
        }
    }
}
