using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Employees;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.DeleteEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdatePasswordEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.ForgotPassword;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail;
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

        [HttpGet("all", Name = "GetAllEmployees"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
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

        [HttpPost(Name = "AddEmployee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var employee = await _mediator.Send(createEmployeeCommand);
            return Ok(employee);
        }

        [HttpPut( Name = "UpdateEmployee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update( [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        { 
          
            await _mediator.Send(updateEmployeeCommand);
            return NoContent();
        }

        [HttpGet("forgotPassword/{Email}", Name = "forgotPassword")]
        public async Task<ActionResult<ForgotPasswordDto>> forgotPassword([FromRoute] string Email)
        {
            var forgotPasswodQuery = new ForgotPasswodQuery() { WorkEmail = Email };
            return Ok(await _mediator.Send(forgotPasswodQuery));
        }


        [HttpDelete("{id}", Name = "DeleteEmployee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(deleteEmployeeCommand);
            return NoContent();
        }
       

 
        [HttpPut("UpdatePasswordEmployee", Name = "UpdatePasswordEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePasswordEmployee([FromBody] UpdatePasswordCommand updatePasswordCommand)
        {

            await _mediator.Send(updatePasswordCommand);
            return NoContent();
        }
    }
}
