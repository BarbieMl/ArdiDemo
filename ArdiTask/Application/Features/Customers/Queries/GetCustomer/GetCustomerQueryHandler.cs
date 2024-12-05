using Application.Common.Contracts.Persistence.Query;
using Application.DTOs;
using Application.Features.Medical.Commands.CreateMedical;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly ICustomerQueryRepository _customer;
        public GetCustomerQueryHandler(ICustomerQueryRepository customer)
        {
            _customer = customer;
        }
        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
           // var result = await _customer.GetByIdAsync(query.Id);
            var result1 = await _customer.GetByIdNumber("123456789");

            //var response = new GetCustomerQueryResponse(
            //     Id: result.Id,
            //     CreateDate: result.CreateDate,
            //     IsActive: result.IsActive,
            //     IdNumber: result.IdNumber,
            //     PassportNumber: result.PassportNumber,
            //     DateOfBirth: result.DateOfBirth,
            //     FirstName: result.FirstName,
            //     LastName: result.LastName,
            //     PhoneNumber: result.PhoneNumber,
            //     Email: result.Email,
            //     Gender: result.Gender,
            //     Citizenship: result.Citizenship,
            //     Address: result.Address,
            //     MedicalPolicies: result.MedicalPolicies?.Select(mp => new MedicalPolicyDto(
            //        Id: mp.Id,
            //        CreateDate: mp.CreateDate,
            //        IsActive: mp.IsActive,
            //        PolicyNumber: mp.PolicyNumber,
            //        StartDate: mp.StartDate,
            //        EndDate: mp.EndDate,
            //        PremiumAmount: mp.PremiumAmount,
            //        Insurer: mp.Insurer,
            //        TypeOfPaymentPeriod: mp.TypeOfPaymentPeriod,
            //        Provider: mp.Provider
            //    )).ToList(),
            //    TravelPolicies: result.TravelPolicies?.Select(tp => new TravelPolicyDto(
            //        Id: tp.Id,
            //        CreateDate: tp.CreateDate,
            //        IsActive: tp.IsActive,
            //        PolicyNumber: tp.PolicyNumber,
            //        StartDate: tp.StartDate,
            //        EndDate: tp.EndDate,
            //        PremiumAmount: tp.PremiumAmount,
            //        Insurer: tp.Insurer,
            //        TypeOfTrip: tp.TypeOfTrip,
            //        TypeOfPaymentPeriod: tp.TypeOfPaymentPeriod,
            //        Countries: tp.Countries
            //    )).ToList()
            // );

            return null;
        }
    }
}
