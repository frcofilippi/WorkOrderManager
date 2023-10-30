using Microsoft.EntityFrameworkCore;

using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Common.ValueObjects;
using WorkUserManager.Application.Common.Repositories;

namespace WorkOrderManager.Infrastructure.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _dbContext;

    public ClientRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Client> Clients => _dbContext.Clients;

    public async Task<Client> AddUser(Client client)
    {
        await _dbContext.Clients.AddAsync(client);
        await _dbContext.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> FindByEmail(string email)
    {
        return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<ClientId?> GetClientIdFromIdentityId(string identityId)
    {
        var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.IdentityId == identityId);
        return client is null ? null : client.ClientId;
    }

    public async Task<Client?> GetUserById(ClientId userId)
    {
        return await _dbContext.Clients.FirstOrDefaultAsync(u => u.ClientId == userId);
    }

    public async Task RemoveUser(Client client)
    {
        _dbContext.Clients.Remove(client);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(Client client)
    {
        _dbContext.Update(client);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> UserAlreadyExists(string email)
    {
         var user = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Email == email);
         return user is not null;
    }
}