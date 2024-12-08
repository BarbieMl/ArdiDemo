using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record TravelPolicyDto
    (
        Guid Id,
        DateTime CreateDate,
        bool IsDeleted,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Insurer,
        TypeOfTrip TypeOfTrip,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        string Countries
    );
}
