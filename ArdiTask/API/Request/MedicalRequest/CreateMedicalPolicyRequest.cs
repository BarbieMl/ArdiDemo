using Domain.Enumeration;

namespace API.Request.CustomerRequest
{
    public record CreateMedicalPolicyRequest(
        string Citizenship, 
        string IdNumber, 
        DateOnly DateOfBirth,
        string PhoneNumber,
        string Email,
        string FirstName,
        string LastName, 
        Gender Gender,
        string Adress,
        DateTime FromDate,
        DateTime EndDate);
}
