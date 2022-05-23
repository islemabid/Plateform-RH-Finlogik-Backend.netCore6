
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
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
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
    }
}
