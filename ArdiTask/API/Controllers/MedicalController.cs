using API.Request.CustomerRequest;
using Application.Features.Medical.Commands.CreateMedical;
using Application.Features.Medical.Commands.DeleteMedical;
using Application.Features.Medical.Commands.UpdateMedical;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("CreateMedicalPolicy")]
        public async Task<ActionResult<CreateMedicalCommandResponse>> CreateMedicalPolicy([FromBody] CreateMedicalCommands command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
           return Ok(result);
        }

        [HttpPut("UpdateMedicalPolicy")]
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
