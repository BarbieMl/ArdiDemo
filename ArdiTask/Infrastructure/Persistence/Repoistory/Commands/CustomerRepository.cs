using Application.Common.Interfaces.Persistence.Commands;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;

namespace Infrastructure.Persistence.Repoistory.Commands
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InsuranceDBContext context)
            : base(context)
        {
        }
    }
}
