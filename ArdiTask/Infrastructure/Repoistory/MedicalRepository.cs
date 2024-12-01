using Application.Interfaces.Persistence.Medical;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repoistory
{
    public class MedicalRepository : IMedicalRepository
    {
        private readonly InsuranceDBContext _context;
        public MedicalRepository(InsuranceDBContext context)
        {
            _context = context; 
        }
        public async Task Add(Customer customer)
        {
            await _context.Add(customer);
            await _context.SaveChanges();
        }
    }

}
