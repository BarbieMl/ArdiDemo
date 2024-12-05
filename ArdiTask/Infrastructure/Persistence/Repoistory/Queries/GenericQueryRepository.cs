using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Dapper;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repoistory.Queries
{
    public class GenericQueryRepository<TEntity> : IGenericQueryRepository<TEntity> where TEntity : class
    {
        private readonly DapperInsuranceDBContext _context; 

        public GenericQueryRepository(DapperInsuranceDBContext context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection =  _context.CreateConnection();
            string sql = $"SELECT * FROM {typeof(TEntity).Name}s";

            //if (connection.State == ConnectionState.Closed)
            //{
            //    await connection.OpenAsync();
            //}
             
            return await connection.QueryAsync<TEntity>(sql); 
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            using var connection =  _context.CreateConnection();
            string sql = $"SELECT * FROM {typeof(TEntity).Name}s Where Id = @Id";

            //if (connection.State == ConnectionState.Closed)
            //{
            //    await connection.OpenAsync();
            //}

            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

    }
}
