namespace Microsoft.Extensions.DependencyInjection;

using System.Text;

using MediatR.Registration;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Application.Services.JwtTokenGenerator;
using WorkOrderManager.Application.Services.TimeProvider;
using WorkOrderManager.Infrastructure.Authentication;
using WorkOrderManager.Infrastructure.Authentication.Identity;
using WorkOrderManager.Infrastructure.Persistence.Repositories;
using WorkOrderManager.Infrastructure.TimeProvider;

using WorkUserManager.Application.Common.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException($"Parameter {nameof(configuration)} cannot be null");
        }

        AddPersistance(services);
        AddAuthenication(services, configuration);
        services.AddSingleton<IDateTimeService, TimeProvider>();
        return services;
    }

    private static void AddAuthenication(IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGenerator>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            });
    }

    private static void AddPersistance(IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
