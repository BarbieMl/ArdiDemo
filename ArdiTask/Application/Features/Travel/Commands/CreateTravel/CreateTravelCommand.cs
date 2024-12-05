using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.CreateTravel
{
    public record CreateTravelCommand
    (
        string Citizenship,
        string IdNumber,
        DateTime DateOfBirth,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        Gender Gender,
        string Address,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount, 
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        TypeOfTrip TypeOfTrip ,
        string Countries 
    ) : IRequest<CreateTravelCommandResponse>;

}
