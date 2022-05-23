

using Plateform_RH_Finlogik.Application.Models.Email;

namespace Plateform_RH_Finlogik.Application.Contracts.Email
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
