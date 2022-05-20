using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.PointageEmployee.Commands.CreatePointage;
using Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetallEmployeesWorkingHours;
using Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetAllWorkingHoursByIDEmployee;


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

        [HttpGet("allWorkingHoursOfAllEmployees", Name = "GetallWorkingHoursOfAllEmployees"),Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Ressources Humaines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<WorkingHoursOfAllEmployees>>> GetallWorkingHoursOfAllEmployees()
        {
            var dtos = await _mediator.Send(new GetAllEmployeesWorkingHoursQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetAllWorkingHoursByIdEmployee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "employee")]
        public async Task<ActionResult<List<AllWorkingHoursOfEmployeeVm>>> GetAllWorkingHoursByIdEmployee(int id)
        {
            var getAllWorkingHoursByIDEmployeeQuery = new GetAllWorkingHoursByIDEmployeeQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(getAllWorkingHoursByIDEmployeeQuery));
        }
       

        [HttpPost(Name = "AddPointage")]
        public async Task<ActionResult> Create([FromBody] CreatePointageCommand createPointageCommand)
        {
            var pointage = await _mediator.Send(createPointageCommand);
            return Ok(pointage);
        }

    }
}
