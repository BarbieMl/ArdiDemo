using API.Request.CustomerRequest;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Customers.Queries.GetCustomer;
using Application.Features.Medical.Commands.CreateMedical;
using Application.Features.Medical.Commands.DeleteMedical;
using Application.Features.Medical.Commands.UpdateMedical;
using Application.Features.Medical.Queries;
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
        public async Task<ActionResult<GetCustomerQueryResponse>> GetByIdAsync([FromQuery] GetCustomerQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token);
            return Ok(result);
        }
        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<IEnumerable<GetCustomerQueryResponse>>> GetAllAsync(CancellationToken token)
        { 
            var result = await _mediator.Send(new GetAllCustomerQuery(), token);
            return Ok(result);
        }

        [HttpDelete("DeletePolicyHolder")]
        public async Task<ActionResult<bool>> DeletePolicyHolder([FromBody] DeleteCustomerCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }

        [HttpPatch("UpdateCustomerPolicy")]
        public async Task<ActionResult<UpdateCustomerCommandResponse>> UpdateCustomerPolicy([FromBody] UpdateCustomerCommand command, CancellationToken token)
        {
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
 
