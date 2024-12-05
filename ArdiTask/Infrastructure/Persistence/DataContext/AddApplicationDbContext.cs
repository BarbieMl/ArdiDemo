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
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.DataContext
{
    public static class AppDbContextExtensions
    { 
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        { 
            services.AddDbContext<InsuranceDBContext>(options =>
               options.UseSqlServer(connectionString));               
            return services;
        }
        public static IServiceCollection AddDapperSupport(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DapperInsuranceDBContext>(provider =>
           new DapperInsuranceDBContext(connectionString));

            services.AddScoped<IDbConnection>(sp =>
           new SqlConnection(connectionString));
            return services;
        }


    }
}
