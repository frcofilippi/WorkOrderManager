namespace WorkOrderManager.Application.Services.JwtTokenGenerator;

public interface IJwtTokenGeneratorService
{
    string CreateJwtToken(Guid userId, string firstName, string lastName);
}