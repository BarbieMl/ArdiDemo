using Application.Common.Contracts.Persistence.Query;
using Application.Features.Medical.Queries.GetAllMedical;
using Application.Features.Travel.Queries.GetByIdMedical;
using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Queries.GetByIdMedical
{
    public class GetTravelQueryHandler : IRequestHandler<GetTravelQuery, GetTravelQueryResponse>
    {

        private readonly ITravelQueryRepository _travel;
        public GetTravelQueryHandler(ITravelQueryRepository travel)
        {
            _travel = travel;
        }
        public async Task<GetTravelQueryResponse> Handle(GetTravelQuery query, CancellationToken cancellationToken)
        {
            var data = await _travel.GetByIdAsync(query.Id);
              
            return new GetTravelQueryResponse(
                Id: data.Id,
                CreateDate: data.CreateDate,
                IsActive: data.IsActive,
                PolicyNumber: data.PolicyNumber,
                StartDate: data.StartDate,
                EndDate: data.EndDate,
                PremiumAmount: data.PremiumAmount,
                Insurer: data.Insurer, 
                TypeOfTrip: data.TypeOfTrip,
                TypeOfPaymentPeriod: data.TypeOfPaymentPeriod,
                Countries: data.Countries);
        }
    }
}
