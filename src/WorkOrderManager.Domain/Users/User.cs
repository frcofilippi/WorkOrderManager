
namespace WorkOrderManager.Domain.Users;

using WorkOrderManager.Domain.Users.ValueObjects;

public class User
{
    private User(UserId id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public UserId Id { get; private set; }

    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public string? Email { get; private set; }

    public string Password { get; private set; }

    public static User CreateUser(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}
