
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.CreateEmployeePay;
using Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.UpdateEmployeePay;
using Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetEmployeePayList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetHistoryPayOfEmployee;


namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class EmployeePayController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeePayController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllEmployeesPays"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeePayListVm>>> GetAllEmployeesPays()
        {
            var dtos = await _mediator.Send(new GetEmployeePayListQuery());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetHistoryPaytsByIdEmployee")]
        public async Task<ActionResult<List<HistoryPayVm>>> GetHistoryPaytsByIdEmployee(int id)
        {
            var getHistoryPayOfEmployeeQuery = new GetHistoryPayOfEmployeeQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(getHistoryPayOfEmployeeQuery));
        }

        [HttpPost(Name = "AddEmployeePay"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        public async Task<ActionResult> Create([FromBody] CreateEmployeePayCommand createEmployeePayCommand)
        {
            var pay = await _mediator.Send(createEmployeePayCommand);
            return Ok(pay);
        }
        [HttpPut(Name = "UpdateEmployeePay"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEmployeePayCommand updateEmployeePayCommand)
        {

            await _mediator.Send(updateEmployeePayCommand);
            return NoContent();
        }
    }
}
