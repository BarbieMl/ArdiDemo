using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Medical.Queries.GetByIdMedical;
using MediatR; 

namespace Application.Features.Travel.Queries.GetAllMedical
{
    public record GetAllTravelQuery() : IRequest<List<GetAllTravelQueryResponse>>;
}
