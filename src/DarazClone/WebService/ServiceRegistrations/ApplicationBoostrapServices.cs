namespace DarazClone.WebService.ServiceRegistrations;

public static class ApplicationBootstrapServices
{
    public static IServiceCollection AddBootstrapServices(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                // This will prevent your api response converted in small case
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
