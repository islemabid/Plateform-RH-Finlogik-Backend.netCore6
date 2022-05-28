using Plateform_RH_Finlogik.Application.Models.Authentification;


namespace Plateform_RH_Finlogik.Application.Contracts.Jwt
{
    public  interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        
    }
}
