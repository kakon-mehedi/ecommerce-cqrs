using System;
using DarazClone.Core.Services.Auth.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DarazClone.Core.Services.Auth;

public static class AuthServiceRegistration
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services){
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }
}
