﻿using Application.Common.Interfaces.Persistence.Commands;
using Application.Common.Interfaces.Persistence.Queries;
using Dapper;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
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
        private readonly InsuranceDBContext _context;

        public GenericQueryRepository(InsuranceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection = _context.Database.GetDbConnection();
            string sql = $"SELECT * FROM {typeof(TEntity).Name}s";

            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
             
            return await connection.QueryAsync<TEntity>(sql); 
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            using var connection = _context.Database.GetDbConnection();
            string sql = $"SELECT * FROM {typeof(TEntity).Name}s Where Id = @Id";

            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

    }
}