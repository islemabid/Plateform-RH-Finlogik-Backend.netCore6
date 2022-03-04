using Plateform_RH_Finlogik.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Contracts.Infrastructure
{
    public  interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
