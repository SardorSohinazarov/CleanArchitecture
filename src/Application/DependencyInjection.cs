using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
