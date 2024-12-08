using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Contracts.Persistence.Query
{
    public interface ICustomerReadRepository : IGenericReadRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync(); 
        Task<Customer> GetCustomerByIdAsync(Guid Id); 
    }
}
