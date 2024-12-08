using Application.Common.Contracts.Persistence.Query;
using MediatR;

namespace Application.Features.Travel.Queries.GetAllMedical
{
    public class GetAllTravelQueryHandler : IRequestHandler<GetAllTravelQuery, List<GetAllTravelQueryResponse>>
    {

        private readonly ITravelReadRepository _travel;
        public GetAllTravelQueryHandler(ITravelReadRepository travel)
        {
            _travel = travel;
        }
        public async Task<List<GetAllTravelQueryResponse>> Handle(GetAllTravelQuery query, CancellationToken cancellationToken)
        {
            var datas = await _travel.GetAllAsync();

            var responses = new List<GetAllTravelQueryResponse>();

            foreach (var data in datas)
            {
                var response = new GetAllTravelQueryResponse(
                    Id: data.Id,
                    CreateDate: data.CreateDate,
                    IsDeleted: data.IsDeleted,
                    PolicyNumber: data.PolicyNumber,
                    StartDate: data.StartDate,
                    EndDate: data.EndDate,
                    PremiumAmount: data.PremiumAmount,
                    Insurer: data.Insurer,
                    TypeOfTrip: data.TypeOfTrip,
                    TypeOfPaymentPeriod: data.TypeOfPaymentPeriod,
                    Countries: data.Countries);

                responses.Add(response);
            }

            return responses;
        }
    }
}
 
