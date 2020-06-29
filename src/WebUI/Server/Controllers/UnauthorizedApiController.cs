using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Maturnik.WebUI.Server.Controllers
{
    [ApiController]
    [Route("unauthorizedApi/[controller]/[action]")]
    public class UnauthorizedApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
