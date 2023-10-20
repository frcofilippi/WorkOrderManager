﻿
namespace Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using WorkOrderManager.Application.Services.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}