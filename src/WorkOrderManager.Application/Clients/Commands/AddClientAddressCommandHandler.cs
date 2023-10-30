using ErrorOr;

using MediatR;

using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Clients.Entities;
using WorkOrderManager.Domain.Common.Errors;
using WorkOrderManager.Domain.Common.ValueObjects;

using WorkUserManager.Application.Common.Repositories;

namespace WorkOrderManager.Application.Clients.Commands;

public record AddClientAddressCommandHandler : IRequestHandler<AddClientAddressCommand, ErrorOr<Client>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IIdentityService _identityService;

    public AddClientAddressCommandHandler(IClientRepository clientRepository, IIdentityService identityService)
    {
        _clientRepository = clientRepository;
        _identityService = identityService;
    }

    public async Task<ErrorOr<Client>> Handle(AddClientAddressCommand request, CancellationToken cancellationToken)
    {
        var requesterId = await _identityService.GetUserId();
        var client = await _clientRepository.GetUserById(ClientId.Create(request.ClientId));
        if (requesterId is not null && requesterId.Value == client.ClientId.Value)
        {
            if (request.isBilling && request.isShipping)
            {
                client.AddNewShippingAddress(request.Name, request.Street, request.StreetNumber, request.City,
                                             request.Country);
                client.AddNewBillingAddress(request.Name, request.Street, request.StreetNumber, request.City,
                                            request.Country);
            }
            else
            {
                if (request.isShipping)
                {
                    client.AddNewShippingAddress(request.Name, request.Street, request.StreetNumber, request.City,
                                                 request.Country);
                }

                if (request.isBilling)
                {
                    client.AddNewBillingAddress(request.Name, request.Street, request.StreetNumber, request.City,
                                                request.Country);
                }
            }

            await _clientRepository.UpdateUser(client);

            return client;
        }

        return Errors.Clients.RequesterAndClientDoesNotMatch;
    }
}
