
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Contrats.Commands.CreateContrat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Commands.DeleteContrat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Commands.UpdateContrat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratByID;
using Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratsList;
using System.Net;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class ContratController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContratController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllContrats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ContratsListVm>>> GetAllContrats()
        {
            var dtos = await _mediator.Send(new GetContratsListQuery());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetContratById")]
        public async Task<ActionResult<ContratByIDdetails>> GetContratById(int id)
        {
            var getContratByIDQuery = new GetContratByIDQuery() { Id = id };
            return Ok(await _mediator.Send(getContratByIDQuery));
        }
        [HttpPost(Name = "AddContrat")]
        public async Task<ActionResult> Create([FromBody] CreateContratCommand createContratCommand)
        {
            var contrat = await _mediator.Send(createContratCommand);
            return Ok(contrat);
        }

        [HttpPut(Name = "UpdateContrat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateContratCommand updateContratCommand)
        {
            await _mediator.Send(updateContratCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteContrat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteContratCommand = new DeleteContratCommand() { Id = id };
            await _mediator.Send(deleteContratCommand);
            return NoContent();
        }
    }
}

