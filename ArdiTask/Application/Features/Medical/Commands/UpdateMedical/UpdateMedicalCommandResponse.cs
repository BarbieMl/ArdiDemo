using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Commands.UpdateMedical
{
    public record UpdateMedicalCommandResponse(
        Guid Id,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Provider,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        bool IsActive
    );
}
