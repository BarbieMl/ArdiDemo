using Application.Common.Contracts.Persistence.Command;
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
