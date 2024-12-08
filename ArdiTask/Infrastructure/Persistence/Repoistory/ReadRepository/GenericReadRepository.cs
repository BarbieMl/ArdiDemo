using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Dapper;
using Domain.Entities;
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
    public class GenericReadRepository<TEntity> : IGenericReadRepository<TEntity> where TEntity : class
    {
        private readonly DapperInsuranceDBContext _context; 

        public GenericReadRepository(DapperInsuranceDBContext context)
        { 
            _context = context;
        }
       
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection =  _context.CreateConnection();
            connection.Open();
            string tableName = GetTableName<TEntity>(); 
            string sql = $"SELECT * FROM {tableName}"; 
            return await connection.QueryAsync<TEntity>(sql); 
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            using var connection =  _context.CreateConnection();
            connection.Open();
            string tableName = GetTableName<TEntity>();
            string sql = $"SELECT * FROM {tableName} Where Id = @Id";  
            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
             
        }

        private string GetTableName<TEntity>()
        {
            string typeName = typeof(TEntity).Name;
            return typeName.EndsWith("y") ? typeName.Substring(0, typeName.Length - 1) + "ies" : typeName + "s";
        }

    }
}
