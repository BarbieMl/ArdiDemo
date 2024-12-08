using Domain.Entities;
using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.UpdateTravel
{
    public record UpdateTravelCommandResponse(
        Guid Id,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        bool IsDeleted,
        TypeOfTrip TypeOfTrip,
        string Countries  
    );
}
