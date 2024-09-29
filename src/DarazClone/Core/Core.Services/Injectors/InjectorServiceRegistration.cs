using System;
using DarazClone.Core.Services.Injectors.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DarazClone.Core.Services.Injectors;

public static class InjectorServiceRegistration
{
    public static IServiceCollection AddInjectorServices(this IServiceCollection services) {
        services.AddTransient<ICommonValueInjectorService, CommonValueInjectorService>();
        services.AddTransient<IMetadataInjectorService, MetadataInjectorService>();
        
        return services;
    }
 }
