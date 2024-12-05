using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetCustomer
{
    public record GetCustomerQuery(Guid Id) : IRequest<GetCustomerQueryResponse>;
}
