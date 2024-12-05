using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Policy : BaseEntity
    {
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PremiumAmount { get; set; }
        public string Insurer {  get; set; }
    }
}
