
using Plateform_RH_Finlogik.Application.Models.Authentication;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
