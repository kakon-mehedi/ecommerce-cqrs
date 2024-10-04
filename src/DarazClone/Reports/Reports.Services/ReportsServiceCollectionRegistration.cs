using System;
using Microsoft.Extensions.DependencyInjection;
using Reports.Services.Implementations;

namespace Reports.Services;

public static class ReportsServiceCollectionRegistration
{
    public static IServiceCollection AddReportServices(this IServiceCollection  services){
        services.AddTransient<IUserReportService, UserReportService>();

        return services;
    }
}
