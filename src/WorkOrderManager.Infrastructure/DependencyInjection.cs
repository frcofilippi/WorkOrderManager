namespace Microsoft.Extensions.DependencyInjection;

using System.Text;

using FirebaseAdmin;

using Google.Apis.Auth.OAuth2;

using MediatR.Registration;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Application.Services.JwtTokenGenerator;
using WorkOrderManager.Application.Services.TimeProvider;
using WorkOrderManager.Infrastructure.Authentication;
using WorkOrderManager.Infrastructure.Authentication.Firebase;
using WorkOrderManager.Infrastructure.Authentication.Identity;
using WorkOrderManager.Infrastructure.Persistence;
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
        // services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGenerator>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = jwtSettings.Issuer;
                options.Audience = jwtSettings.Audience;
                options.TokenValidationParameters.ValidIssuer = jwtSettings.Issuer;
            });

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("firebase.json"),
        });
        services.AddHttpClient<IJwtTokenGeneratorService, FirebaseJwtTokenGenerator>((sp, client) =>
        {
            var firebaseSettings = new FirebaseSettings();
            configuration.Bind(FirebaseSettings.SectionName, firebaseSettings);
            client.BaseAddress = new Uri(string.Concat(firebaseSettings.Url, firebaseSettings.ApiKey));
        });
        services.AddScoped<IAuthenticationServiceV2, FirebaseAuthService>();
    }

    private static void AddPersistance(IServiceCollection services)
    {

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("default");
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
    }
}
