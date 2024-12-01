using API.Request.CustomerRequest;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
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
        public IActionResult CreatePolicy([FromBody] CreateMedicalRequest request)
        {
           return Ok();
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
