using Application.DTOs;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Queries.GetByIdMedical
{
    public record GetMedicalQueryResponse(
        Guid Id,
        DateTime CreateDate,
        bool IsDeleted,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        string Provider);
}
