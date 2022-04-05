using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Candidats.Commands.CreateCandidat;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCandidat")]
        public async Task<ActionResult> Create([FromBody] CreateCandidatCommand createCandidatCommand)
        {
            var candidat = await _mediator.Send(createCandidatCommand);
            return Ok(candidat);
        }
    }
}
