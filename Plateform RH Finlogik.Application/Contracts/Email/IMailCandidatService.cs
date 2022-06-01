using Plateform_RH_Finlogik.Application.Models.Email;


namespace Plateform_RH_Finlogik.Application.Contracts.Email
{
    public interface IMailCandidatService
    {
        Task SendEmailCandidatAsync(MailRequest mailRequest);
    }
}
