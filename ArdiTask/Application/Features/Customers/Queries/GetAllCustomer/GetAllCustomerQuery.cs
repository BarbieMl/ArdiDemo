using Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomer
{
    public record GetAllCustomerQuery() : IRequest<List<GetAllCustomerQueryResponse>>;
}
