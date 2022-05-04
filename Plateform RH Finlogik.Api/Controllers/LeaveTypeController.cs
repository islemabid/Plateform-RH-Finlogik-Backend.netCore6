using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.LeaveTypes.Queries.GetListLeaveType;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allLeaveType", Name = "GetAllLeaveType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LeaveTypeListVm>>> GetAllLeaveType()
        {
            var dtos = await _mediator.Send(new GetListLeaveTypeQuery());
            return Ok(dtos);
        }

    }
}
