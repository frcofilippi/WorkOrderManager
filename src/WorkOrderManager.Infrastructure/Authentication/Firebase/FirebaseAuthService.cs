using ErrorOr;

using FirebaseAdmin.Auth;

using Microsoft.AspNetCore.Authentication.OAuth;

using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Application.Services.JwtTokenGenerator;

namespace WorkOrderManager.Infrastructure.Authentication.Firebase;

public class FirebaseAuthService : IAuthenticationServiceV2
{
    private readonly IJwtTokenGeneratorService _jwtService;

    public FirebaseAuthService(IJwtTokenGeneratorService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<ErrorOr<AuthToken>> LoginUser(string username, string password)
    {
        return await _jwtService.GetCredentialsAsync(username, password);
    }

    public async Task<ErrorOr<string>> RegisterUser(string username, string password)
    {
        var userArgs = new UserRecordArgs
        {
            Email = username,
            Password = password
        };
        var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
        return userRecord.Uid;
    }
}