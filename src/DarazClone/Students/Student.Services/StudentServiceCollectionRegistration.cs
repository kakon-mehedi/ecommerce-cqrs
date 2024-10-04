using System;
using DarazClone.Students.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DarazClone.Students.Services;

public static class StudentServiceCollectionRegistration
{
    public static IServiceCollection AddStudentServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();

        return services;
    }
}
