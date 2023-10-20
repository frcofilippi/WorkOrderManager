using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Orders.ValueObjects;

namespace WorkUserManager.Application.Common.Repositories;

public interface IClientRepository
{
    IReadOnlyCollection<Client> Users { get; }

    Task<Client> AddUser(Client user);

    Task RemoveUser(Client user);

    Task UpdateUser(Client user);

    Task<Client?> GetUserById(ClientId userId);

    Task<Client?> FindByEmail(string email);

    Task<bool> UserAlreadyExists(string email);
}