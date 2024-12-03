using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Persistence;
using Infrastructure.Repoistory;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {  
            service.AddScoped<IMedicalRepository, MedicalRepository>(); 
            service.AddScoped<ICustomerRepository, CustomerRepository>(); 

            return service; 
        }    
    }
}
