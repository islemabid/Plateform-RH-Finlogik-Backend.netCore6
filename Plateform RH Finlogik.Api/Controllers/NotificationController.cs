using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationCount;
using Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage;
using System.Net;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
    [ApiController]
    public class NotificationController : ControllerBase

    {
        private readonly IMediator _mediator;

     public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("message", Name = "GetNotificationMessage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<NotificationResult>>> GetNotificationMessage()
    {
        var dtos = await _mediator.Send(new GetNotificationMessageQuery());
        return Ok(dtos);
    }



    [HttpGet("notificationcount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
     public async Task<ActionResult<NotificationCountResult>> GetNotificationCount()
     {
            var count = await _mediator.Send(new GetNotificationCountQuery());
            return Ok(count);
     }

    }
}
