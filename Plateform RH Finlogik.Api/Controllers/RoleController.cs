using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.CreateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.DeleteRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.UpdateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RolesListVm>>> GetAllRoles()
        {
            var dtos = await _mediator.Send(new GetRolesListQuery());
            return Ok(dtos);
        }
      

        [HttpPost(Name = "AddRole")]
        public async Task<ActionResult> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            var role = await _mediator.Send(createRoleCommand);
            return Ok(role);
        }

        [HttpPut(Name = "UpdateRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            await _mediator.Send(updateRoleCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRoleCommand = new DeleteRoleCommand() { Id = id };
            await _mediator.Send(deleteRoleCommand);
            return NoContent();
        }
    }
}





