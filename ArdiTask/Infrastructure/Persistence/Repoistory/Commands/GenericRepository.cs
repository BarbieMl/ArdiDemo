using Application.Common.Contracts.Persistence.Command;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repoistory.Commands
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly InsuranceDBContext context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(InsuranceDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<TEntity>();
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
             return await _entities
                .Where(predicate)
                .FirstOrDefaultAsync(); 
        }
        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Delete(Guid id)
        {
            TEntity existing = _entities.Find(id);
            _entities.Remove(existing);
        }


        public async Task Update(TEntity entity)
        {
            _entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            //_entities.Update(entity);   
        }
    }
}
