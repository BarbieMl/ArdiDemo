using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Repoistory.Commands;
using Application.Common.Contracts.Persistence.Command;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistence.DataContext;
using Infrastructure.Persistence.Repoistory.EFCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Infrastructure.Persistence.Repoistory.Queries;
using Application.Common.Contracts.Persistence.Query;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Infrastructure.Persistence.Repoistory.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration config)
        {


            service.AddApplicationDbContext(config.GetConnectionString("DefaultConnection"));
            service.AddDapperSupport(config.GetConnectionString("DefaultConnection"));
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped(typeof(IGenericQueryRepository<>), typeof(GenericQueryRepository<>));

            service.AddScoped<IMedicalRepository, MedicalRepository>();  
            service.AddScoped<ICustomerRepository, CustomerRepository>(); 
            service.AddScoped<ITravelRepository, TravelRepository>(); 
            service.AddScoped<IMedicalQueryRepository, MedicalQueryRepository>();
            service.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            service.AddScoped<ITravelQueryRepository, TravelQueryRepository>();

            return service; 
        }    
    }
}
