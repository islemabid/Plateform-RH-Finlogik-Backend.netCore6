
using Microsoft.AspNetCore.Http;
using Plateform_RH_Finlogik.Application.Contracts;
using System.Security.Claims;

namespace Plateform_RH_Finlogik.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
