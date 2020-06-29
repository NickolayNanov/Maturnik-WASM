using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Maturnik.Application.Common.Interfaces;

namespace Maturnik.WebUI.Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
