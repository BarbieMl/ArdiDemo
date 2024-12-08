using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommandResponse(
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
        string Address
    );
}
