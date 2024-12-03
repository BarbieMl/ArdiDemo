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

namespace Infrastructure.Persistence.DataContext
{
    public static class AppDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<InsuranceDBContext>(option =>
                {
                    option.UseNpgsql(connectionString);
                });
            service.AddScoped<IDbConnection>(sp =>
            new SqlConnection(connectionString));
        }
    }
}
