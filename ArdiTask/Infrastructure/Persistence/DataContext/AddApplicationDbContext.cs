using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Npgsql;

namespace Infrastructure.Persistence.DataContext
{
    public static class AppDbContextExtensions
    { 
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        { 
            services.AddDbContext<InsuranceDBContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
        public static IServiceCollection AddDapperSupport(this IServiceCollection services, string connectionString)
        {
            //services.AddScoped<DapperInsuranceDBContext>(sp =>
            //    new DapperInsuranceDBContext(connectionString));  // Make sure connectionString is provided properly

            services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString));
            return services;
        }


    }
}
