using DarazClone.Core.Services;
using DarazClone.Products.Services;
using Reports.Services;



namespace DarazClone.WebService.ServiceRegistrations;


public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoreServices(configuration);
        services.AddApplicationServices();
        services.AddApplicationCommandHandlers();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        
        services.AddProductServices();
        services.AddReportServices();
        return services;
    }
}