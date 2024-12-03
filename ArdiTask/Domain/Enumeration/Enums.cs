using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumeration
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public enum TypeOfTrip
    {
        SingleVisit = 1,
        DoubleVisit = 2,
        TripleVisit = 3
    }

    public enum TypeOfPaymentPeriod
    {
        OneTime = 1,
        Monthly = 2,
        Quarterly = 3,
        Annually = 4,
        SemiAnnually = 5
    }

}
