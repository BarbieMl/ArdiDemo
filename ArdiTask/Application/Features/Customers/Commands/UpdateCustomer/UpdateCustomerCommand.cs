using Application.Features.Medical.Commands.CreateMedical;
using Domain.Enumeration;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(
        Guid Id,
        string IdNumber,
        string PassportNumber,
        DateTime DateOfBirth,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        Gender Gender,
        string Citizenship,
        string Address,
        bool IsActive
    ) : IRequest<UpdateCustomerCommandResponse>;
}