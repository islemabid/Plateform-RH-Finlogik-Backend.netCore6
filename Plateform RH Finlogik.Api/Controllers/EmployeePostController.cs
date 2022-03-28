using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Commands.createEmployeePost;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class EmployeePostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeePostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEmployeesPosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeePostListVm>>> GetAllEmployeesPosts()
        {
            var dtos = await _mediator.Send(new GetEmployeePostListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPostsByIdEmployee")]
        public async Task<ActionResult<List<PostListByIDEmployeeVm>>> GetPostsByIdEmployees(int id)
        {
            var PostsByEmployeeIDListQuery = new GetPostsByEmployeeIDListQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(PostsByEmployeeIDListQuery));
        }

      
    }
}
