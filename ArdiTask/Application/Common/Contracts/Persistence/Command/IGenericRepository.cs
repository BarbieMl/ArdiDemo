using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Contracts.Persistence.Command
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task SaveAsync();
        void Delete(Guid id);
    }
}
