using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Contracts.Persistence.Query
{
    public interface ICustomerQueryRepository : IGenericQueryRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithRelationsAsync();
        Task<Customer> GetByIdAsync(Guid Id);
        Task<Customer?> GetByIdNumber(string IdNumber);
    }
}
