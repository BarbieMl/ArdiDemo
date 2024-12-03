using API.Request.CustomerRequest;
using Application.Features.Medical.Commands.CreateMedical;
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
        // GET: api/<MedicalInsuranceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MedicalInsuranceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedicalInsuranceController>
        [HttpPost("CreatePolicy")]
        public async Task<ActionResult<CreateMedicalCommandResponse>> CreatePolicy([FromBody] CreateMedicalCommand command)
        {
            var result = await _mediator.Send(command);
           return Ok(result);
        }

        // PUT api/<MedicalInsuranceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicalInsuranceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
