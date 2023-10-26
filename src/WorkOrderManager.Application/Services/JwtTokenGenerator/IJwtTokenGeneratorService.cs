namespace WorkOrderManager.Application.Services.JwtTokenGenerator;

public interface IJwtTokenGeneratorService
{
    string CreateJwtToken(Guid userId, string firstName, string lastName);

    Task<AuthToken> GetCredentialsAsync(string user, string password);
}

public record AuthToken(string Email, string IdToken, long ExpiresIn, string RefreshToken, bool Registered);
