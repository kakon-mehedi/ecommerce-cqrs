using System;
using System.Reflection;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Products.CommandHandlers;
using DarazClone.Products.QueryHandlers;
using DarazClone.Students.CommandHandlers;


namespace DarazClone.WebService.ServiceRegistrations;

public static class ApplicationCommandHandlerRegistrations
{
    public static IServiceCollection AddApplicationCommandHandlers(this IServiceCollection services)
    {
        // Creating new array of Assemblies
        Assembly[] assembliesToScan = [
            typeof(AddProductCommandHandler).Assembly, // As we are selecting the assembly here. so This will add Todo.CommandHandler projects all command handlers.
            typeof(GetAllProductsQueryHandler).Assembly,
            typeof(CreateStudentCommandHandler).Assembly,
        ];
       

        var handlerTypes = assembliesToScan
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t =>
                t.GetInterfaces()
                    .Any(i =>
                        i.IsGenericType
                        && (
                            i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)
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
