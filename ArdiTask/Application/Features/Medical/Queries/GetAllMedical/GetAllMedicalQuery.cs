using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Medical.Queries.GetByIdMedical;
using MediatR; 

namespace Application.Features.Medical.Queries.GetAllMedical
{
    public record GetAllMedicalQuery() : IRequest<List<GetAllMedicalQueryResponse>>;
}
