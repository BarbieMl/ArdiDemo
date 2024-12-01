using Application.Interfaces.Persistence.Medical;
using Infrastructure.DataContext;
using Microsoft.Extensions.DependencyInjection; 
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{ 
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, Configuration config)
        {  
            service.AddScoped<IMedicalRepository, IMedicalRepository>();
            
            return service; 
        }    
    }
}
