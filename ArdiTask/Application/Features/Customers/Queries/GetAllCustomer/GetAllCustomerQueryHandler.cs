using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Application.DTOs;
using Application.Features.Customers.Queries.GetCustomer;
using AutoMapper;
using Domain.Entities;
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

        private readonly ICustomerReadRepository _customer;
        private readonly IMapper _mapper;
        public GetAllCustomerQueryHandler(ICustomerReadRepository customer, IMapper mapper)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        { 
            var data = await _customer.GetAllCustomerAsync();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("No customers found.");
            }

            //var responses = data.Select(result => _mapper.Map<GetAllCustomerQueryResponse>(result)).ToList();
            var response = new List<GetAllCustomerQueryResponse>(); 
            foreach (var result in data)
            {
                var item = new GetAllCustomerQueryResponse
                {
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
                    MedicalPolicies = result.MedicalPolicies?.Select(mp => new MedicalPolicyDto
                    {
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

                response.Add(item);

            }

            return response;
        }
    }
}
