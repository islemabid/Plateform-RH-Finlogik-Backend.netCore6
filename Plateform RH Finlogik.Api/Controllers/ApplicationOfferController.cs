using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOfferByID;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOffersList;

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
           [HttpGet("all", Name = "GetAllApplicationOffers"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
           [ProducesResponseType(StatusCodes.Status200OK)]
           public async Task<ActionResult<List<ApplicationOffersListVm>>> GetApplicationOffersList()
           {
                var dtos = await _mediator.Send(new GetApplicationOffersListQuery());
                return Ok(dtos);
           }

        [HttpGet("{id}", Name = "GetApplicationOfferById"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        public async Task<ActionResult<ApplicationOfferDetails>> GetApplicationOfferById(int id)
        {
            var getApplicationOfferById = new GetApplicationOfferByIdQuery() { Id = id };
            return Ok(await _mediator.Send(getApplicationOfferById));
        }

        [HttpPost(Name = "AddapplicationOffer")]
          public async Task<ActionResult> Create([FromBody] CreateApplicationOfferCommand createApplicationOfferCommand)
            {
                var applicationOffer = await _mediator.Send(createApplicationOfferCommand);
                return Ok(applicationOffer);
            }
        }
}
