using Application.Common.Contracts.Persistence.Query;
using Application.DTOs;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Medical.Commands.CreateMedical;
using AutoMapper;
using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly ICustomerReadRepository _customer;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(ICustomerReadRepository customer, IMapper mapper)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var result = await _customer.GetCustomerByIdAsync(query.Id);

            if (result == null)
            {
                throw new InvalidOperationException("No customers found.");
            }
            //  return _mapper.Map<GetCustomerQueryResponse>(result);

            return new GetCustomerQueryResponse {
                Id = result.Id,
                CreateDate = result.CreateDate,
                IsDeleted = result.IsDeleted,
                IdNumber = result.IdNumber,
                PassportNumber = result.PassportNumber,
                DateOfBirth = result.DateOfBirth,
                FirstName = result.FirstName,
                LastName = result.LastName,
                PhoneNumber = result.PhoneNumber,
                Email = result.Email,
                Gender = result.Gender,
                Citizenship = result.Citizenship,
                Address = result.Address,
                MedicalPolicies = result.MedicalPolicies?.Select(mp => new MedicalPolicyDto {
                    Id = mp.Id,
                    CreateDate = mp.CreateDate,
                    IsDeleted = mp.IsDeleted,
                    PolicyNumber = mp.PolicyNumber,
                    StartDate = mp.StartDate,
                    EndDate = mp.EndDate,
                    PremiumAmount = mp.PremiumAmount,
                    Insurer = mp.Insurer,
                    TypeOfPaymentPeriod = mp.TypeOfPaymentPeriod,
                    Provider = mp.Provider
                }).ToList(),
                TravelPolicies = result.TravelPolicies?.Select(tp => new TravelPolicyDto
                {
                    Id = tp.Id,
                    CreateDate = tp.CreateDate,
                    IsDeleted = tp.IsDeleted,
                    PolicyNumber = tp.PolicyNumber,
                    StartDate = tp.StartDate,
                    EndDate = tp.EndDate,
                    PremiumAmount = tp.PremiumAmount,
                    Insurer = tp.Insurer,
                    TypeOfTrip = tp.TypeOfTrip,
                    TypeOfPaymentPeriod = tp.TypeOfPaymentPeriod,
                    Countries = tp.Countries
                }).ToList()

            }; 

        }
    }
}
