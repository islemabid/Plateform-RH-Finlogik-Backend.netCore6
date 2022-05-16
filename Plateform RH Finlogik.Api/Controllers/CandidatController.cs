using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Candidats.Commands.CreateCandidat;
using Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatByID;
using Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatsList;

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


        [HttpGet("all", Name = "GetAllCandidats"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CandidatsListVm>>> GetAllCandidats()
        {
            var dtos = await _mediator.Send(new GetCandidatsListQuery());
            return Ok(dtos);
        }



        [HttpGet("{id}", Name = "GetCandidatById"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        public async Task<ActionResult<CandidatDetails>> GetCandidatById(int id)
        {
            var getCandidatByID = new GetCandidatByIDQuery() { Id = id };
            return Ok(await _mediator.Send(getCandidatByID));
        }


        [HttpPost(Name = "AddCandidat")]
        public async Task<ActionResult> Create([FromBody] CreateCandidatCommand createCandidatCommand)
        {
            var candidat = await _mediator.Send(createCandidatCommand);
            return Ok(candidat);
        }
    }
}
