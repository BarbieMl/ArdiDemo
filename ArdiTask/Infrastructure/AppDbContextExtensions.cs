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
using Infrastructure.Persistence.DataContext;
using Application.Common.SoftDelete;

namespace Infrastructure
{
    public static class AppDbContextExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<InsuranceDBContext>((s, options) =>
               options.UseSqlServer(connectionString)
               .AddInterceptors(
                        s.GetRequiredService<SoftDeleteInterceptor>()));
            return services; 
        }


        public static IServiceCollection AddDapperSupport(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(provider =>
           new DapperInsuranceDBContext(connectionString));

            services.AddScoped<IDbConnection>(sp =>
           new SqlConnection(connectionString));
            return services;
        }


    }
}
