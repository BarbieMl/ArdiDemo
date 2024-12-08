using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Customers.Queries.GetCustomer;
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
        

        [HttpGet("GetById")]
        public async Task<ActionResult<GetCustomerQueryResponse>> GetById([FromQuery] GetCustomerQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetAllCustomerQueryResponse>>> GetAll(CancellationToken token)
        { 
            var result = await _mediator.Send(new GetAllCustomerQuery(), token);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteCustomerCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<UpdateCustomerCommandResponse>> Update([FromBody] UpdateCustomerCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
 
