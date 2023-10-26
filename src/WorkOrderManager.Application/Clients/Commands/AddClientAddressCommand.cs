using ErrorOr;

using MediatR;

using WorkOrderManager.Domain.Clients;

namespace WorkOrderManager.Application.Clients.Commands;

public record AddClientAddressCommand(
    string Name, string Street, int StreetNumber, string City, bool isBilling, bool isShipping,
    Guid ClientId, string Country) : IRequest<ErrorOr<Client>>
{
}
