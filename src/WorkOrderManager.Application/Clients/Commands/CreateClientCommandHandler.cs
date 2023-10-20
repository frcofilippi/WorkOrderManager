using ErrorOr;
using MediatR;
using WorkOrderManager.Domain.Clients;
using WorkUserManager.Application.Common.Repositories;

namespace WorkOrderManager.Application.Clients.Commands;

public class CreateClientCommandHandler
: IRequestHandler<CreateClientCommand, ErrorOr<Client>>
{
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var newClient = Client.CreateUser(request.FirstName, request.LastName, request.Email, request.Password);
        await _clientRepository.AddUser(newClient);
        return newClient;
    }
}
