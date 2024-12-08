using Application.Common.Contracts.Persistence.Query;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Travel.Queries.GetByIdMedical;
using AutoMapper;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Travel.Queries.GetAllMedical
{
    public class GetAllTravelQueryHandler : IRequestHandler<GetAllTravelQuery, List<GetAllTravelQueryResponse>>
    {

        private readonly ITravelReadRepository _travel; 
        private readonly IMapper _mapper;
        public GetAllTravelQueryHandler(ITravelReadRepository travel, IMapper mapper)
        {
            _travel = travel;
            _mapper = mapper;
        }
        public async Task<List<GetAllTravelQueryResponse>> Handle(GetAllTravelQuery query, CancellationToken cancellationToken)
        {
            var data = await _travel.GetAllAsync();
             
            var responses = data.Select(result => _mapper.Map<GetAllTravelQueryResponse>(result)).ToList();

            return responses;
            //var responses = new List<GetAllTravelQueryResponse>();

            //foreach (var data in datas)
            //{
            //    var response = new GetAllTravelQueryResponse(
            //        Id: data.Id,
            //        CreateDate: data.CreateDate,
            //        IsDeleted: data.IsDeleted,
            //        PolicyNumber: data.PolicyNumber,
            //        StartDate: data.StartDate,
            //        EndDate: data.EndDate,
            //        PremiumAmount: data.PremiumAmount,
            //        Insurer: data.Insurer,
            //        TypeOfTrip: data.TypeOfTrip,
            //        TypeOfPaymentPeriod: data.TypeOfPaymentPeriod,
            //        Countries: data.Countries);

            //    responses.Add(response);
            //}

            //return responses;
        }
    }
}
 
