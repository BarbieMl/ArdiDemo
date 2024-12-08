using Application.Common.Contracts.Persistence.Query;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repoistory.Queries
{
    public class TravelReadRepository : GenericReadRepository<TravelPolicy>, ITravelReadRepository
    {
        public TravelReadRepository(DapperInsuranceDBContext context)
            : base(context)
        {
        }
    }
}
