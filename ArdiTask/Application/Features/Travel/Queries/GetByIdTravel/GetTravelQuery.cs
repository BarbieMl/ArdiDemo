using Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Queries.GetByIdMedical
{
    public record GetTravelQuery(Guid Id) : IRequest<GetTravelQueryResponse>;
}

