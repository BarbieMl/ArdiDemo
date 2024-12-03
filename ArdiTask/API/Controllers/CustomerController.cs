using API.Request.CustomerRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(CreateMedicalPolicyRequest request)
        {
            return Ok();
        }
    }
}
