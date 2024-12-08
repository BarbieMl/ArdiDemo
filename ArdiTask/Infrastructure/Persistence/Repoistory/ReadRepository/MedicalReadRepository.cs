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
    public class MedicalReadRepository : GenericReadRepository<MedicalPolicy>, IMedicalReadRepository
    {
        public MedicalReadRepository(DapperInsuranceDBContext context)
            : base(context)
        {
        }
    }
}
