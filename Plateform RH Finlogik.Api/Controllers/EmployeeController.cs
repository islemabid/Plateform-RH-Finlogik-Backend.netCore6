using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Employees;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeesListQuery());
            return Ok(dtos);
        }
    }
}
