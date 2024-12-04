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

    public sealed class DapperInsuranceDBContext : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        public IDbConnection dbConnection;
        private ConcurrentBag<NpgsqlConnection> _connections = new ConcurrentBag<NpgsqlConnection>();

        // Constructor that accepts a connection string
        public DapperInsuranceDBContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Open a new database connection
        public NpgsqlConnection OpenConnection(CancellationToken cancellationToken)
        {
            // Only open a new connection if one doesn't already exist
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

        // Dispose of all open connections
        public void Dispose()
        {
            // Dispose all connections stored in the bag
            foreach (var item in _connections)
            {
                item.Dispose();
            }

            // Clear the collection of connections
            _connections.Clear();

            // Suppress finalization to prevent unnecessary cleanup in GC
            GC.SuppressFinalize(this);
        }
    }
    public sealed class DapperInsuranceDBContextwe : IDisposable
    {
        private readonly string? _connectionString;
        private IDbConnection? _connection;
        private ConcurrentBag<SqlConnection> _connections = new ConcurrentBag<SqlConnection>();

        public DapperInsuranceDBContextwe(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            _connections.Add(connection);

            return connection;
        }

        public void Dispose()
        {
            foreach (var item in _connections)
            {
                item.Dispose();
            }
            _connections.Clear();

            GC.SuppressFinalize(this);
        }

    }

}


