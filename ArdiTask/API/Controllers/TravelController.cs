
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
        [HttpGet("GetTravelPolicy")]
        public async Task<ActionResult<GetTravelQueryResponse>> GetTravelPolicy([FromQuery] GetTravelQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }

        [HttpGet("GetAllTravelPolicyAsync")]
        public async Task<ActionResult<IEnumerable<GetAllTravelQueryResponse>>> GetAllTravelPolicyAsync(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllTravelQuery(), token);
            return Ok(result);

        }

        [HttpPost("CreateTravelPolicy")]
        public async Task<ActionResult<CreateTravelCommandResponse>> CreateTravelPolicy([FromBody] CreateTravelCommands command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpPatch("UpdateTravelPolicy")]
        public async Task<ActionResult<UpdateTravelCommandResponse>> UpdateTravelPolicy([FromBody] UpdateTravelCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete("DeleteTravelPolicy")]
        public async Task<ActionResult<bool>> DeleteTravelPolicy([FromBody] DeleteTravelCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
