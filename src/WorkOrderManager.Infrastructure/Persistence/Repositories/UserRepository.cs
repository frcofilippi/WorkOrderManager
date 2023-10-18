
namespace WorkOrderManager.Infrastructure.Persistence.Repositories;

using WorkOrderManager.Domain.Users;
using WorkOrderManager.Domain.Users.ValueObjects;

using WorkUserManager.Application.Common.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

    public async Task<User> AddUser(User user)
    {
        _users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task<User?> FindByEmail(string email)
    {
        var user = _users.FirstOrDefault(x => x.Email == email);

        return user is null ? null : await Task.FromResult(user);
    }

    public async Task<User?> GetUserById(UserId userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        return await Task.FromResult(user);
    }

    public async Task RemoveUser(User user)
    {
        await Task.FromResult(_users.Remove(user));
    }

    public async Task UpdateUser(User user)
    {
        await Task.FromResult(1);
    }

    public async Task<bool> UserAlreadyExists(string email)
    {
         var user = _users.FirstOrDefault(x => x.Email == email);

         return user is null ? await Task.FromResult(false) : await Task.FromResult(true);
    }
}