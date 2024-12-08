

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(typeof(DependencyInjection).Assembly);
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return service; 
        }    
    }
}
