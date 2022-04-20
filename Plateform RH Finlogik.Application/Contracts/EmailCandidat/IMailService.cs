

using Plateform_RH_Finlogik.Application.Models.EmailCandidat;

namespace Plateform_RH_Finlogik.Application.Contracts.EmailCandidat
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
