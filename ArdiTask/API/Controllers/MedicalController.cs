using API.Request.CustomerRequest;  
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
        [HttpGet("GetMedicalPolicy")]
        public async Task<ActionResult<GetMedicalQueryResponse>> GetMedicalPolicy([FromQuery] GetMedicalQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }

        [HttpGet("GetAllMedicalPolicyAsync")]
        public async Task<ActionResult<IEnumerable<GetAllMedicalQueryResponse>>> GetAllMedicalPolicyAsync(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllMedicalQuery(), token);
            return Ok(result); 

        }

        [HttpPost("CreateMedicalPolicy")]
        public async Task<ActionResult<CreateMedicalCommandResponse>> CreateMedicalPolicy([FromBody] CreateMedicalCommands command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
           return Ok(result);
        }

        [HttpPatch("UpdateMedicalPolicy")]
        public async Task<ActionResult<UpdateMedicalCommandResponse>> UpdateMedicalPolicy([FromBody] UpdateMedicalCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete("DeleteMedicalPolicy")]
        public async Task<ActionResult<bool>> DeleteMedicalPolicy([FromBody] DeleteMedicalCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
