using MediatR;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ApplicationOfferController : ControllerBase
        {
            private readonly IMediator _mediator;

            public ApplicationOfferController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost(Name = "AddapplicationOffer")]
            public async Task<ActionResult> Create([FromBody] CreateApplicationOfferCommand createApplicationOfferCommand)
            {
                var applicationOffer = await _mediator.Send(createApplicationOfferCommand);
                return Ok(applicationOffer);
            }
        }
}
