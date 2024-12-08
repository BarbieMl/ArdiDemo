using Application.Common.Contracts.Persistence.Command;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repoistory.Commands
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly InsuranceDBContext _context;
        public CustomerRepository(InsuranceDBContext context)
            : base(context)
        {
            _context = context; 
        }
        public async Task<Customer> GetCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Include(c => c.MedicalPolicies)
                .Include(c => c.TravelPolicies)
                .FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);
        }
    }
}
