
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Contracts.EmailCandidat;
using Plateform_RH_Finlogik.Application.Models.EmailCandidat;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailCandidatController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailCandidatController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("Send"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
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
