
namespace WorkOrderManager.Application.Services.Authentication;

using ErrorOr;
using WorkOrderManager.Application.Services;
using WorkOrderManager.Application.Services.JwtTokenGenerator;
using WorkOrderManager.Domain.Common.Errors;
using WorkOrderManager.Domain.Users;
using WorkUserManager.Application.Common.Repositories;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGeneratorService _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGeneratorService jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> RegisterUser(string firstName, string lastName, string username, string password)
    {
        var isAlreadyRegistered = await _userRepository.UserAlreadyExists(username);
        if (isAlreadyRegistered)
        {
            return Errors.Authentication.UserAlreadyExist;
        }

        var user = User.CreateUser(firstName, lastName, username, password);

        await _userRepository.AddUser(user);

        return new AuthenticationResult()
        {
            Success = true,
            Username = user.Email,
            Token = _jwtTokenGenerator.CreateJwtToken(user.Id.Value, user.FirstName, user.LastName),
        };
    }

    public async Task<ErrorOr<AuthenticationResult>> LoginUser(string username, string password)
    {
        var user = await _userRepository.FindByEmail(username);
        return user is null || user.Password != password
            ? Errors.Authentication.WrongLoginInformation
            : new AuthenticationResult()
            {
                Username = user.Email,
                Success = true,
                Token = _jwtTokenGenerator.CreateJwtToken(user.Id.Value, user.FirstName, user.LastName),
            };
    }
}