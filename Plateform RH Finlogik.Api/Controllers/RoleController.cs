using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<RolesListVm>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetRolesListQuery());
            return Ok(dtos);
        }
       

       
    }
}
