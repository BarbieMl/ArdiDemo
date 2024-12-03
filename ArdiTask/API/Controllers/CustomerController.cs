using API.Request.CustomerRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("GetWithPolicies")]
        public async Task<ActionResult<int>> GetWithPolicies()
        {
            return Ok();
        }
        [HttpGet("GetAllWithPolicies")]
        public async Task<ActionResult<int>> GetAllWithPolicies()
        {
            return Ok();
        }

        [HttpGet("Get")]
        public async Task<ActionResult<int>> Get()
        {
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<int>> GetAll()
        {
            return Ok();
        }
    }
}
 
