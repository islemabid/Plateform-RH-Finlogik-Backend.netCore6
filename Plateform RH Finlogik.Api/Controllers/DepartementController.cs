using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.CreateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.DeleteDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.UpdateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList;
using System.Net;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllDepartements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartementsListVm>>> GetAllDepartements()
        {
            var dtos = await _mediator.Send(new GetDepartementsListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddDepartement")]
        public async Task<ActionResult> Create([FromBody] CreateDepartementCommand createDepartementCommand)
        {
            var dep = await _mediator.Send(createDepartementCommand);
            return Ok(dep);
        }

        [HttpPut(Name = "UpdateDepartement")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDepartementCommand updateDepartementCommand)
        {
            await _mediator.Send(updateDepartementCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDepartement")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteDepartementCommand = new DeleteDepartementCommand() { Id = id };
            await _mediator.Send(deleteDepartementCommand);
            return NoContent();
        }
    }
}

