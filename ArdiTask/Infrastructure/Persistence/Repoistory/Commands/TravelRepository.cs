using Application.Common.Contracts.Persistence.Command;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Infrastructure.Persistence.Repoistory.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repoistory.EFCore
{
    public class TravelRepository : GenericRepository<TravelPolicy>, ITravelRepository
    {
        public TravelRepository(InsuranceDBContext context)
            : base(context)
        {
        }
    }
}
