using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plateform_RH_Finlogik.Application.Contracts.Infrastructure;
using Plateform_RH_Finlogik.Application.Models;
using Plateform_RH_Finlogik.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }


}
