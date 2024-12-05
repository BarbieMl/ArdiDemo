using Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Queries.GetByIdMedical
{
    public record GetMedicalQuery(Guid Id) : IRequest<GetMedicalQueryResponse>;
}

