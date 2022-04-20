
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Core;
using Plateform_RH_Finlogik.Application.Contracts.EmailCandidat;
using Plateform_RH_Finlogik.Application.Models.EmailCandidat;
using Plateform_RH_Finlogik_.Infrastructure.MailServices;

namespace Plateform_RH_Finlogik_.Infrastructure
{
    public static  class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
