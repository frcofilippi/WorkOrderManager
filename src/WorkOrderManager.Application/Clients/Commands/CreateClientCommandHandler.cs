using ErrorOr;
using MediatR;

using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Domain.Clients;
using WorkUserManager.Application.Common.Repositories;

namespace WorkOrderManager.Application.Clients.Commands;

public class CreateClientCommandHandler
: IRequestHandler<CreateClientCommand, ErrorOr<Client>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IAuthenticationServiceV2 _authService;

    public CreateClientCommandHandler(IClientRepository clientRepository, IAuthenticationServiceV2 authService)
    {
        _clientRepository = clientRepository;
        _authService = authService;
    }

    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var identityId = await _authService.RegisterUser(request.Email, request.Password);
        var newClient = Client.CreateUser(request.FirstName, request.LastName, request.Email, identityId.Value);
        await _clientRepository.AddUser(newClient);
        return newClient;
    }
}
