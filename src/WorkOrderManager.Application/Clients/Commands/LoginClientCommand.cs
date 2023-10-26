using ErrorOr;

using MediatR;

using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Application.Services.JwtTokenGenerator;

namespace WorkOrderManager.Application.Clients.Commands;

public record LoginClientCommand(string Username, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

public record LoginClientCommandHanlder : IRequestHandler<LoginClientCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IAuthenticationServiceV2 _authenticationService;

    public LoginClientCommandHanlder(IAuthenticationServiceV2 authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginClientCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<AuthToken> result = await _authenticationService.LoginUser(request.Username, request.Password);
        return result.Match(
            token => new AuthenticationResult()
            {
                Success = true,
                Token = token.IdToken,
                RefreshToken = token.RefreshToken,
                ExpiresIn = token.ExpiresIn,
            },
            err => new AuthenticationResult() { Success = false });
    }
}
