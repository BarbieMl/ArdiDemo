using Application.DTOs;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Queries.GetByIdMedical
{
    public record GetTravelQueryResponse(
        Guid Id,
        DateTime CreateDate,
        bool IsActive,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Insurer, 
        TypeOfTrip TypeOfTrip,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        string Countries);
}
