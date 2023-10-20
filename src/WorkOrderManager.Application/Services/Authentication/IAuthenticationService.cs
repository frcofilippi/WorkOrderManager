
using ErrorOr;

namespace WorkOrderManager.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<ErrorOr<AuthenticationResult>> RegisterUser(string firstName, string lastName, string username, string password);
    Task<ErrorOr<AuthenticationResult>> LoginUser(string username, string password);
}
