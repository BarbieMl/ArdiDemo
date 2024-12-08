using Application.DTOs;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomer
{
    public record GetAllCustomerQueryResponse(
        Guid Id,
        DateTime CreateDate,
        bool IsDeleted,
        string IdNumber,
        string PassportNumber,
        DateOnly DateOfBirth,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        Gender Gender,
        string Citizenship,
        string Address,
        List<MedicalPolicyDto?>? MedicalPolicies,
        List<TravelPolicyDto?>? TravelPolicies);
}
