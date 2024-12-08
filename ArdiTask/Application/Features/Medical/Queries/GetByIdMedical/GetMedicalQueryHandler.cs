using Application.Common.Contracts.Persistence.Query;
using Application.Features.Medical.Queries.GetAllMedical;
using Application.Features.Travel.Queries.GetByIdMedical;
using AutoMapper;
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

        private readonly IMedicalReadRepository _medical;
        private readonly IMapper _mapper;
        public GetMedicalQueryHandler(IMedicalReadRepository medical, IMapper mapper)
        {
            _medical = medical;
            _mapper = mapper;
        }
        public async Task<GetMedicalQueryResponse> Handle(GetMedicalQuery query, CancellationToken cancellationToken)
        {
            var data = await _medical.GetByIdAsync(query.Id);


            var responses = _mapper.Map<GetMedicalQueryResponse>(data);

            return responses;
            //return new GetMedicalQueryResponse(
            //    Id: data.Id,
            //    CreateDate: data.CreateDate,
            //    IsDeleted: data.IsDeleted,
            //    PolicyNumber: data.PolicyNumber,
            //    StartDate: data.StartDate,
            //    EndDate: data.EndDate,
            //    PremiumAmount: data.PremiumAmount,
            //    Insurer: data.Insurer,
            //    TypeOfPaymentPeriod: data.TypeOfPaymentPeriod,
            //    Provider: data.Provider);
        }
    }
}
