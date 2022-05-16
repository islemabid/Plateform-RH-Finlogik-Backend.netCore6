
using Microsoft.IdentityModel.Tokens;
using Plateform_RH_Finlogik.Application.Contracts.Jwt;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Models.Authentification;
using Plateform_RH_Finlogik_._JWT.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Plateform_RH_Finlogik_._JWT.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEmployeeRepository _employeeRepository;
    
        public AuthenticationService( IEmployeeRepository employeeRepository)
        {
            
            _employeeRepository = employeeRepository;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            if (request != null && request.Email != null && request.Password != null)
            {
                var user = await _employeeRepository.GetUser(request.Email, Helper.Encrypt(request.Password));
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, "JWTServiceAccessToken"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("DisplayName", user.FirstName),
                        new Claim("UserName", user.LastName),
                        new Claim("Email", user.PersonnelEmail),
                        new Claim(ClaimTypes.Role, user.Role.Name)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                       "JWTAuthenticationServer",
                       "JWTServicePostmanClient",
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(12000),
                        signingCredentials: signIn);

                    return new AuthenticationResponse() { Token = new JwtSecurityTokenHandler().WriteToken(token) };
                }
                else
                {
                    throw new Exception($"failed");
                }
            }
            else
            {
                throw new Exception($"user not found");
            }
        }

        


        /*  public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
          {
              var existingUser = await _userRepository.GetByEmailAsync(request.PersonnelEmail);
              if (existingUser == null)
              {
                  request.ID = new Guid();
                  var @user = _mapper.Map<User>(request);

                  var result = await _userRepository.AddAsync(@user);
                  if (result != null)
                  {
                      return new RegistrationResponse() { message = "success registration" };
                  }
                  else
                  {
                      throw new Exception($"failed");
                  }
              }
              else
              {
                  throw new Exception($"Email  already exists.");
              }

          }
        */
    }
}
