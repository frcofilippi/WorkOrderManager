namespace Microsoft.Extensions.DependencyInjection;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string? Issuer { get; init; }

    public string? Audience { get; init; }

    public int LifeTimeInMinutes { get; init; }

    public string SecretKey { get; set; }
}