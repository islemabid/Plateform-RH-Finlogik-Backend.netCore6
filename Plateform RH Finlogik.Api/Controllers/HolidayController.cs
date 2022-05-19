
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.Holiday.Commands.CreateHoliday;
using Plateform_RH_Finlogik.Application.Features.Holiday.Queries.GetAllHolidays;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public HolidayController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all", Name = "GetAllHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HolidayVm>>> GetAllHolidays()
        {
            var dtos = await _mediator.Send(new GetAllHolidaysQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddHoliday"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        public async Task<ActionResult> Create([FromBody] CreateHolidayCommand createHolidayCommand)
        {
            var holiday = await _mediator.Send(createHolidayCommand);
            return Ok(holiday);
        }
    }
}
