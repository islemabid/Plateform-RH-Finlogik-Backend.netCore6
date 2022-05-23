
using Microsoft.Extensions.DependencyInjection;
using Plateform_RH_Finlogik.Application.Contracts.Email;
using Plateform_RH_Finlogik_.InfrastructureMail.MailServices;

namespace Plateform_Rh_Finlogik.InfrastructureMail
{
    public static class InfrastructureServiceExtension
    {
       
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            
            services.AddTransient<IMailService, MailService>();
            




           
        }
    }
}