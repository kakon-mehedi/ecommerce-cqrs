using DarazClone.Core.Services.Auth;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Injectors;
using DarazClone.Core.Services.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DarazClone.Core.Services;

public static class CoreServiceRegistration
{
     public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDispatcherServices();
        services.AddMiddlewareServices();
        services.AddMongoDbRepositoryServices(configuration);
        services.AddInjectorServices();
        services.AddAuthServices();
        
        return services;
    }
}
