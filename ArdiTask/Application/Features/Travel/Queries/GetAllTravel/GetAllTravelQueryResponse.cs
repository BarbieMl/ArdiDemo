﻿using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Queries.GetAllMedical
{
    public record GetAllTravelQueryResponse(
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