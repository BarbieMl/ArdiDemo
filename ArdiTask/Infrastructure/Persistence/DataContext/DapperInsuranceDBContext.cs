using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DataContext
{
    using Npgsql;
    using System.Collections.Concurrent;
    using System.Data;

    public sealed class DapperInsuranceDBContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        private ConcurrentBag<NpgsqlConnection> _connections = new ConcurrentBag<NpgsqlConnection>();
         
        public DapperInsuranceDBContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        public IDbConnection OpenConnection()
        {
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }

            var sqlConnection = _connection as NpgsqlConnection;
            if (sqlConnection != null)
            {
                _connections.Add(sqlConnection);
            }

            return sqlConnection;
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    } 

}


