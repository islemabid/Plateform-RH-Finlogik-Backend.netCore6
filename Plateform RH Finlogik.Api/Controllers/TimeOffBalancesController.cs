using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.DeleteTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.UpdateTimeOffBalances;
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


        [HttpPost(Name = "AddTimeoffBalances")]
        public async Task<ActionResult> Create([FromBody] CreateTimeOffBalancesCommand createTimeOffBalancesCommand)
        {
            var timeoffbalances = await _mediator.Send(createTimeOffBalancesCommand);
            return Ok(timeoffbalances);
        }
        [HttpGet("{id}", Name = "GetTimeOffBalancesListByEmployeeId")]
        public async Task<ActionResult<ListTimeOffBalancesOfEmployeeVm>> GetTimeOffBalancesListByEmployeeId(int id)
        {
            var getTimeOffByEmployeeIDQuery = new GetTimeOffByEmployeeIDQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(getTimeOffByEmployeeIDQuery));
        }

        [HttpPut(Name = "Updatetimeoffbalances")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTimeOffBalancesCommand updateTimeOffBalancesCommand)
        {
            await _mediator.Send(updateTimeOffBalancesCommand);
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
    }
}

