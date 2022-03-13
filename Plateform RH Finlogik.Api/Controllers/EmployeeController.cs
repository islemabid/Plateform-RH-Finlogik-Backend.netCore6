using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Employees;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.DeleteEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;

namespace Plateform_RH_Finlogik.Api.Controllers
{
 
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
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
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailVm>> GetEmployeeById(int id)
        {
            var getEmployeeDetailQuery = new GetEmployeeDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEmployeeDetailQuery));
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var employee = await _mediator.Send(createEmployeeCommand);
            return Ok(employee);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(deleteEmployeeCommand);
            return NoContent();
        }
    }
}
