using MediatR;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.PointageEmployee.Commands.CreatePointage;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PointageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddPointage")]
        public async Task<ActionResult> Create([FromBody] CreatePointageCommand createPointageCommand)
        {
            var pointage = await _mediator.Send(createPointageCommand);
            return Ok(pointage);
        }

    }
}
