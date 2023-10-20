using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Orders.ValueObjects;
using WorkUserManager.Application.Common.Repositories;

namespace WorkOrderManager.Infrastructure.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private static readonly List<Client> _users = new ();

    public IReadOnlyCollection<Client> Users => _users.AsReadOnly();

    public async Task<Client> AddUser(Client user)
    {
        _users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task<Client?> FindByEmail(string email)
    {
        var user = _users.FirstOrDefault(x => x.Email == email);
        return await Task.FromResult(user);
    }

    public async Task<Client?> GetUserById(ClientId userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        return await Task.FromResult(user);
    }

    public async Task RemoveUser(Client user)
    {
        await Task.FromResult(_users.Remove(user));
    }

    public async Task UpdateUser(Client user)
    {
        await Task.FromResult(1);
    }

    public async Task<bool> UserAlreadyExists(string email)
    {
         var user = _users.FirstOrDefault(x => x.Email == email);

         return user is null ? await Task.FromResult(false) : await Task.FromResult(true);
    }
}