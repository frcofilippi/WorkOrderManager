
namespace WorkOrderManager.Presentation.Controllers;

using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOrderManager.Presentation.Contracts.Authentincation;
using IAuthenticationService = WorkOrderManager.Application.Services.Authentication.IAuthenticationService;
using AuthenticationResult = WorkOrderManager.Application.Services.Authentication.AuthenticationResult;

public class AuthController : ApiController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> response = await _authenticationService.LoginUser(request.Username, request.Password);
        return response.Match(
            result => new ObjectResult(_mapper.Map<AuthenticationReponse>(result)),
            errors => Problem(errors));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
    {
        ErrorOr<AuthenticationResult> response = await _authenticationService.RegisterUser(request.FirstName, request.LastName, request.Username, request.Password);
        return response.Match(
            result => new OkObjectResult(_mapper.Map<AuthenticationReponse>(result)),
            errors => Problem(errors));
    }
}