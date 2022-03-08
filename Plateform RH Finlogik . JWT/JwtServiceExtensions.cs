using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Plateform_RH_Finlogik.Application.Contracts.Jwt;
using Plateform_RH_Finlogik_._JWT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik_._JWT
{
    public static class JwtServiceExtensions
    {
       
        public static void AddJwtServices(this IServiceCollection Services, IConfiguration Configuration)
        {
             
            //System.Diagnostics.Debugger.Launch();
            Services.AddTransient<IAuthenticationService, AuthenticationService>();

           Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "JWTServicePostmanClient",
                    ValidIssuer = "JWTAuthenticationServer",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"))
                };
            });
           






        }
    }
}
