using Application.Features.Medical.Commands.CreateMedical;
using Application.Features.Medical.Commands.DeleteMedical;
using Application.Features.Medical.Commands.UpdateMedical;
using Application.Features.Medical.Queries.GetAllMedical;
using Application.Features.Medical.Queries.GetByIdMedical;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedicalController(IMediator mediator)
        {

            _mediator = mediator;

        }
        [HttpGet("Get")]
        public async Task<ActionResult<GetMedicalQueryResponse>> Get([FromQuery] GetMedicalQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetAllMedicalQueryResponse>>> GetAll(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllMedicalQuery(), token);
            return Ok(result); 

        }

        [HttpPost("Create")]
        public async Task<ActionResult<CreateMedicalCommandResponse>> Create([FromBody] CreateMedicalCommands command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
           return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<UpdateMedicalCommandResponse>> Update([FromBody] UpdateMedicalCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteMedicalCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
