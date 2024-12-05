using Application.Common.Contracts.Persistence.Query;
using Application.Features.Medical.Queries.GetAllMedical;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Queries.GetByIdMedical
{
    public class GetMedicalQueryHandler : IRequestHandler<GetMedicalQuery, GetMedicalQueryResponse>
    {

        private readonly IMedicalQueryRepository _medical;
        public GetMedicalQueryHandler(IMedicalQueryRepository medical)
        {
            _medical = medical;
        }
        public async Task<GetMedicalQueryResponse> Handle(GetMedicalQuery query, CancellationToken cancellationToken)
        {
            var data = await _medical.GetByIdAsync(query.Id);
              
            return new GetMedicalQueryResponse(
                Id: data.Id,
                CreateDate: data.CreateDate,
                IsActive: data.IsActive,
                PolicyNumber: data.PolicyNumber,
                StartDate: data.StartDate,
                EndDate: data.EndDate,
                PremiumAmount: data.PremiumAmount,
                Insurer: data.Insurer,
                TypeOfPaymentPeriod: data.TypeOfPaymentPeriod,
                Provider: data.Provider);
        }
    }
}
