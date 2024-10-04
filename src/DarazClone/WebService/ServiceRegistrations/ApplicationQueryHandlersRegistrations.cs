using System;
using System.Reflection;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Students.QueryHandlers;

namespace DarazClone.WebService.ServiceRegistrations;

public static class ApplicationQueryHandlersRegistrations
{
    public static IServiceCollection AddApplicationQueryHandlers(this IServiceCollection services)
    {
        Assembly[] assemblies = [
           typeof(GetAllStudentsQueryHandler).Assembly, // As we are selecting the assembly here. so This will add Todo.CommandHandler projects all command handlers.
            
        ];


        var handlerTypes = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t =>
                t.GetInterfaces()
                    .Any(i =>
                        i.IsGenericType
                        && (
                            i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
                            || i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
                        )
                    )
            )
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces().First(i => i.IsGenericType);
            services.AddScoped(interfaceType, handlerType);
        }

        return services;
    }
}
