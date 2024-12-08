using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record TravelPolicyDto
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; init; }
        public bool IsDeleted { get; init; }
        public string PolicyNumber { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public decimal PremiumAmount { get; init; }
        public string Insurer { get; init; }
        public TypeOfTrip TypeOfTrip { get; init; }
        public TypeOfPaymentPeriod TypeOfPaymentPeriod { get; init; }
        public string Countries { get; init; }
    }
}
