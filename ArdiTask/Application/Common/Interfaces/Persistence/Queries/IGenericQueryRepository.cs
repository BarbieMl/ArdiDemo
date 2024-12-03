using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence.Queries
{
    public interface IGenericQueryRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
       // Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
