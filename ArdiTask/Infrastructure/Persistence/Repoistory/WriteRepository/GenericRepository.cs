using Application.Common.Contracts.Persistence.Command;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Persistence.Repoistory.Commands
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, ISoftDelete
    {
        private readonly InsuranceDBContext _context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(InsuranceDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<TEntity>();
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _entities.AddAsync(entity);
        }
         
        public async Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            _context.Set<TEntity>().Update(entity);
        }


        public async Task Update(TEntity entity, CancellationToken cancellationToken)
        {  
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
              
        }
    }
}
