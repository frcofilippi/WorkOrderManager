
namespace WorkOrderManager.Application.Services.Authentication;

public record AuthenticationResult
{
    public string Token { get; set; }
    public string Username { get; set; }
    public bool Success { get; set; }
    public string RefreshToken { get; internal set; }
    public long ExpiresIn { get; internal set; }
}

public record FirebaseAuthenticationResult(string IdentityId);