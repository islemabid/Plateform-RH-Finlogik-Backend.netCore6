using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.CreateOffer;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.DeleteOffer;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.updateOffer;
using Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOfferById;
using Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOffersList;
using System.Net;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {   
           private readonly IMediator _mediator;

            public OfferController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("all", Name = "GetAllOffers")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<List<OffersListVm>>> GetAllOffers()
            {
                var dtos = await _mediator.Send(new GetOffersListQuery());
                return Ok(dtos);
            }
            [HttpGet("{id}", Name = "GetOfferById")]
            public async Task<ActionResult<OfferVm>> GetOfferById(int id)
            {
            var getofferByIDQuery = new GetOfferByIdQuery() { Id = id };
            return Ok(await _mediator.Send(getofferByIDQuery));
            }

        [HttpPost(Name = "AddOffer"),Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
            public async Task<ActionResult> Create([FromBody] CreateOfferCommand createOfferCommand)
            {
                var offer = await _mediator.Send(createOfferCommand);
                return Ok(offer);
            }

            [HttpPut(Name = "UpdateOffer"),Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesDefaultResponseType]
            public async Task<ActionResult> Update([FromBody] UpdateOfferCommand updateOfferCommand)
            {
                await _mediator.Send(updateOfferCommand);
                return NoContent();
            }

            [HttpDelete("{id}", Name = "DeleteOffer"),Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesDefaultResponseType]
            public async Task<ActionResult> Delete(int id)
            {
                var deleteOfferCommand = new DeleteOfferCommand() { Id = id };
                await _mediator.Send(deleteOfferCommand);
                return NoContent();
            }
        }
    }

