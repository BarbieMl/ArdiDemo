using Application.Common.Contracts.Persistence.Query;
using Application.DTOs;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Medical.Queries.GetByIdMedical;
using Application.Features.Travel.Queries.GetAllMedical;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Queries.GetAllMedical
{
    public class GetAllMedicalQueryHandler : IRequestHandler<GetAllMedicalQuery, List<GetAllMedicalQueryResponse>>
    {

        private readonly IMedicalReadRepository _medical;
        private readonly IMapper _mapper;
        public GetAllMedicalQueryHandler(IMedicalReadRepository medical, IMapper mapper)
        {
            _medical = medical;
            _mapper = mapper;
        }
        public async Task<List<GetAllMedicalQueryResponse>> Handle(GetAllMedicalQuery query, CancellationToken cancellationToken)
        {
            var data = await _medical.GetAllAsync();


            var responses = data.Select(c => _mapper.Map<GetAllMedicalQueryResponse>(c)).ToList();

            return responses;

            //var responses = new List<GetAllMedicalQueryResponse>();

            //foreach (var item in data)
            //{
            //    var response = new GetAllMedicalQueryResponse(
            //        Id: item.Id,
            //        CreateDate: item.CreateDate,
            //        IsDeleted: item.IsDeleted,
            //        PolicyNumber: item.PolicyNumber,
            //        StartDate: item.StartDate,
            //        EndDate: item.EndDate,
            //        PremiumAmount: item.PremiumAmount,
            //        Insurer: item.Insurer,
            //        TypeOfPaymentPeriod: item.TypeOfPaymentPeriod,
            //        Provider: item.Provider
            //    );

            //    responses.Add(response);
            //}

            //return responses;
        }
    }
}
 
