using ErrorOr;

using WorkOrderManager.Application.Services.JwtTokenGenerator;

namespace WorkOrderManager.Application.Services.Authentication;

public interface IAuthenticationServiceV2
{
    Task<ErrorOr<string>> RegisterUser(string username, string password);

    Task<ErrorOr<AuthToken>> LoginUser(string username, string password);
}