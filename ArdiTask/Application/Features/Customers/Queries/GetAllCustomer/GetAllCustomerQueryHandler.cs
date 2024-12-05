using Application.Common.Contracts.Persistence.Query;
using Application.DTOs;
using Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<GetAllCustomerQueryResponse>>
    {

        private readonly ICustomerQueryRepository _customer;
        public GetAllCustomerQueryHandler(ICustomerQueryRepository customer)
        {
            _customer = customer;
        }
        public async Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        { 
            var data = await _customer.GetAllCustomerAsync();
             
            var responses = new List<GetAllCustomerQueryResponse>();
             
            foreach (var result in data)
            {
                var response = new GetAllCustomerQueryResponse(
                    Id: result.Id,
                    CreateDate: result.CreateDate,
                    IsActive: result.IsActive,
                    IdNumber: result.IdNumber,
                    PassportNumber: result.PassportNumber,
                    DateOfBirth: new DateOnly(result.DateOfBirth.Year, result.DateOfBirth.Month, result.DateOfBirth.Day),
                    FirstName: result.FirstName,
                    LastName: result.LastName,
                    PhoneNumber: result.PhoneNumber,
                    Email: result.Email,
                    Gender: result.Gender,
                    Citizenship: result.Citizenship,
                    Address: result.Address,
                    MedicalPolicies: result.MedicalPolicies?.Select(mp => new MedicalPolicyDto(
                        Id: mp.Id,
                        CreateDate: mp.CreateDate,
                        IsActive: mp.IsActive,
                        PolicyNumber: mp.PolicyNumber,
                        StartDate: mp.StartDate,
                        EndDate: mp.EndDate,
                        PremiumAmount: mp.PremiumAmount,
                        Insurer: mp.Insurer,
                        TypeOfPaymentPeriod: mp.TypeOfPaymentPeriod,
                        Provider: mp.Provider
                    )).ToList(),
                    TravelPolicies: result.TravelPolicies?.Select(tp => new TravelPolicyDto(
                        Id: tp.Id,
                        CreateDate: tp.CreateDate,
                        IsActive: tp.IsActive,
                        PolicyNumber: tp.PolicyNumber,
                        StartDate: tp.StartDate,
                        EndDate: tp.EndDate,
                        PremiumAmount: tp.PremiumAmount,
                        Insurer: tp.Insurer,
                        TypeOfTrip: tp.TypeOfTrip,
                        TypeOfPaymentPeriod: tp.TypeOfPaymentPeriod,
                        Countries: tp.Countries
                    )).ToList()
                );
                 
                responses.Add(response);
            }
             
            return responses;
        }
    }
}
