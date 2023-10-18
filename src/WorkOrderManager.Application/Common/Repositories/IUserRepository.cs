namespace WorkUserManager.Application.Common.Repositories;

using WorkOrderManager.Domain.Users;
using WorkOrderManager.Domain.Users.ValueObjects;

public interface IUserRepository
{
    IReadOnlyCollection<User> Users { get; }

    Task<User> AddUser(User user);

    Task RemoveUser(User user);

    Task UpdateUser(User user);

    Task<User?> GetUserById(UserId userId);

    Task<User> FindByEmail(string email);

    Task<bool> UserAlreadyExists(string email);
}
