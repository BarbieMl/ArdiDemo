using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TravelPolicy : Policy
    {       
        public TypeOfTrip TypeOfTrip { get; set; }
        public TypeOfPaymentPeriod TypeOfPaymentPeriod { get; set; }
        public string Countries {  get; set; }

    }
}
