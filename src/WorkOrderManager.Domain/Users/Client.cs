namespace WorkOrderManager.Domain.Clients;

using WorkOrderManager.Domain.Orders.ValueObjects;
using WorkOrderManager.Domain.Clients.Entities;

public class Client
{
    private readonly List<Address?> _addresses = new ();

    private Client(ClientId id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public ClientId Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public IReadOnlyCollection<Address?> ShippingAddresses => _addresses.Where(a => a.IsShipping).ToList();

    public IReadOnlyCollection<Address?> BillingAddresses => _addresses.Where(a => a.IsBilling).ToList();

    public void AddNewShippingAddress(string name, string street, int number, string city, string country = "AR")
    {
        _addresses.Add(Address.Create(name, street, number, city, country, false, true));
    }

    public void AddNewBillingAddress(string name, string street, int number, string city, string country = "AR")
    {
        _addresses.Add(Address.Create(name, street, number, city, country, true, false));
    }

    public static Client CreateUser(string firstName, string lastName, string email, string password)
    {
        return new Client(ClientId.CreateUnique(), firstName, lastName, email, password);
    }
}
