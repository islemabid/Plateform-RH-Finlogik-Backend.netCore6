
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Contracts.Email;
using Plateform_RH_Finlogik.Application.Models.Email;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IMailCandidatService _candidatMail;
        public MailController(IMailService mailService, IMailCandidatService candidatMail)
        {
            _mailService = mailService;
            _candidatMail = candidatMail;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromBody] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       /* [HttpPost("SendCandidatMail")]
        public async Task<IActionResult> SendMail([FromBody] MailRequest request)
        {
            try
            {
                await _candidatMail.SendEmailCandidatAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }*/
    }
}
