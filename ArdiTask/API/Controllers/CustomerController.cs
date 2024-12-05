using API.Request.CustomerRequest;
using Application.Features.Customers.Queries.GetCustomer;
using Application.Features.Medical.Commands.CreateMedical;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {

            _mediator = mediator;

        }
        

        [HttpGet("GetByIdAsync")]
        public async Task<ActionResult<GetCustomerQueryResponse>> GetByIdAsync([FromQuery] Guid Id, CancellationToken token)
        {
            var query = new GetCustomerQuery(Id);
            var result = _mediator.Send(query, token);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<int>> GetAll()
        {
            return Ok();
        }
        // to do : customer edit, customer remove, costomer get
    }
}
 
