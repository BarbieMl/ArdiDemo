using Application.DTOs;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomer
{
    public record GetAllCustomerQueryResponse
     {   public Guid Id { get; init; }
    public DateTime CreateDate { get; init; }
    public bool IsDeleted { get; init; }
    public string IdNumber { get; init; }
    public string PassportNumber { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public Gender Gender { get; init; }
    public string Citizenship { get; init; }
    public string Address { get; init; }
    public List<MedicalPolicyDto?>? MedicalPolicies { get; init; }
    public List<TravelPolicyDto?>? TravelPolicies { get; init; }
    }
}
