using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContext
{
    public static class InsuranceDBContextExtensions 
    { 
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString) =>
          services.AddDbContext<InsuranceDBContext>(options =>
               options.UseSqlite(connectionString));

    }
}
