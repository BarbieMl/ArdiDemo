using Application.Common.Contracts.Persistence.Command;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repoistory.Commands
{
    public class MedicalRepository : GenericRepository<MedicalPolicy>, IMedicalRepository
    { 
        public MedicalRepository(InsuranceDBContext context)
            : base(context)
        {  
        }
    }

}
