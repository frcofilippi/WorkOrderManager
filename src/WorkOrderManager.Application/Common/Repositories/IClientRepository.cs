using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Common.ValueObjects;

namespace WorkUserManager.Application.Common.Repositories;

public interface IClientRepository
{
    Task<Client> AddUser(Client user);

    Task RemoveUser(Client user);

    Task UpdateUser(Client user);

    Task<Client?> GetUserById(ClientId userId);

    Task<Client?> FindByEmail(string email);

    Task<bool> UserAlreadyExists(string email);

    Task<ClientId?> GetClientIdFromIdentityId(string identityId);
}
