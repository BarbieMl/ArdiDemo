using Application.Features.Travel.Commands.CreateTravel;
using Application.Features.Travel.Commands.DeleteTravel;
using Application.Features.Travel.Commands.UpdateTravel;
using Application.Features.Travel.Queries.GetAllMedical;
using Application.Features.Travel.Queries.GetByIdMedical;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TravelController(IMediator mediator)
        {

            _mediator = mediator;

        }
        [HttpGet("Get")]
        public async Task<ActionResult<GetTravelQueryResponse>> Get([FromQuery] GetTravelQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetAllTravelQueryResponse>>> GetAll(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllTravelQuery(), token);
            return Ok(result);

        }

        [HttpPost("Create")]
        public async Task<ActionResult<CreateTravelCommandResponse>> Create([FromBody] CreateTravelCommands command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<UpdateTravelCommandResponse>> Update([FromBody] UpdateTravelCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteTravelCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
