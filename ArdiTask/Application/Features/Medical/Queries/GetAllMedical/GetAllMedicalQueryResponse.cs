using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Queries.GetAllMedical
{
    public record GetAllMedicalQueryResponse(Guid Id,
        DateTime CreateDate,
        bool IsActive,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        string Provider);
}
