using System;
using Microsoft.Extensions.DependencyInjection;
using Products.Services.Implementations;

namespace DarazClone.Products.Services;

public static class ProductServicesRegistration
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        return services;
    }
}
