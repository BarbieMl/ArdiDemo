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
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using System.Collections.Concurrent;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    public class DapperInsuranceDBContext
    {
        private readonly string _connectionString; 

        public DapperInsuranceDBContext(string connectionString)
        {
            _connectionString = connectionString;

        }  
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString); 
        
    }
    

}


