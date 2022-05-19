
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Command.CancelTimeOffBalances;

using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.DeleteTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.RefuseTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.ValidateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetLeaveTotalByIdEmployee;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffBalancesList;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffByEmployeeID;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeOffBalancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeOffBalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTimeOffBalances")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TimeoffBalancesListVm>>> GetAllTimeOffBalances()
        {
            var dtos = await _mediator.Send(new GetTimeOffBalancesListQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddTimeoffBalances"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "employee")]
        public async Task<ActionResult> Create([FromBody] CreateTimeOffBalancesCommand createTimeOffBalancesCommand)
        {
            var timeoffbalances = await _mediator.Send(createTimeOffBalancesCommand);
            return Ok(timeoffbalances);
        }
        [HttpGet("ListByEmployeeId/{id}", Name = "GetTimeOffBalancesListByEmployeeId"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "employee")]
        public async Task<ActionResult<ListTimeOffBalancesOfEmployeeVm>> GetTimeOffBalancesListByEmployeeId(int id)
        {
            var getTimeOffByEmployeeIDQuery = new GetTimeOffByEmployeeIDQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(getTimeOffByEmployeeIDQuery));
        }

        [HttpPut(Name = "Validatetimeoffbalances"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Validate([FromBody] ValidateTimeOffBalancesCommand ValidateTimeOffBalancesCommand)
        {
            await _mediator.Send(ValidateTimeOffBalancesCommand);
            return NoContent();
        }

        [HttpPut( "Refuse",Name = "Refusetimeoffbalances"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Refuse([FromBody] RefuseTimeOffBalancesCommand RefuseTimeOffBalancesCommand)
        {
            await _mediator.Send(RefuseTimeOffBalancesCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTimeOffBalances")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteTimeOffBalances = new DeleteTimeOffBalancesCommand() { Id = id };
            await _mediator.Send(deleteTimeOffBalances);
            return NoContent();
        }
      
        [HttpDelete("cancel/{idRequest}", Name = "GetRequestTocancel")]
        public async Task<ActionResult> GetRequestTocancel(int idRequest)
        {
            var cancelTimeOffBalancesCommand = new CancelTimeOffBalancesCommand() { Id = idRequest };
            return Ok(await _mediator.Send(cancelTimeOffBalancesCommand));
        }


        [HttpGet("LeaveTotalByIdEmployee/{idEmployee}", Name = "GetLeaveTotalByIdEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LeaveTotalByIdEmployeeVm>> GetLeaveTotalByIdEmployee( int idEmployee)
        {
            var dtos = await _mediator.Send(new GetLeaveTotalByIdEmployeeQuery() { IdEmployee = idEmployee });
            return Ok(dtos);
        }
    }
}

