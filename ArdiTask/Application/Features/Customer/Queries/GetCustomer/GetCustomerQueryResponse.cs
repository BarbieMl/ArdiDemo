using Application.DTOs;
using Domain.Entities;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetCustomer
{
    public record GetCustomerQueryResponse(
        Guid Id,
        DateTime CreateDate,
        bool IsActive,
        string IdNumber ,
        string PassportNumber,
        DateOnly DateOfBirth,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        Gender Gender,
        string Citizenship,
        string Address,
        List<MedicalPolicyDto> MedicalPolicies,
        List<TravelPolicyDto> TravelPolicies);
}
