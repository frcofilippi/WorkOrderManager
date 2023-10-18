
namespace WorkOrderManager.Application.Services;

public record AuthenticationResult
{
    public string Token { get; set; }
    public string Username { get; set; }
    public bool Success { get; set; }
}