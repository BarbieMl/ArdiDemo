using Application.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.DataContext;

namespace Infrastructure.Repoistory
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceDBContext _context;
        public CustomerRepository(InsuranceDBContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
