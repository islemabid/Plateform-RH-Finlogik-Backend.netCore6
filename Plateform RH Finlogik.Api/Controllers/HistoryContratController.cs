using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryContratController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HistoryContratController(IMediator mediator)
        {
            _mediator = mediator;
        }

      

        [HttpGet("{id}", Name = "GetHistoryContratsByIdEmployee")]
        public async Task<ActionResult<List<HistoryContratsListByEmployeeIDVm>>> GetHistoryContratsByIdEmployee(int id)
        {
            var HistoryContratsByEmployeeIDListQuery = new GetHistoryContratsByEmployeeIDQuery() { IdEmployee = id };
            return Ok(await _mediator.Send(HistoryContratsByEmployeeIDListQuery));
        }


    }
}

  


