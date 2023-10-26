namespace WorkOrderManager.Domain.Clients;

using WorkOrderManager.Domain.Orders.ValueObjects;
using WorkOrderManager.Domain.Clients.Entities;
using WorkOrderManager.Domain.Orders;

public class Client
{
    private readonly List<Address?> _addresses = new ();
    private readonly List<Order?> _orders = new ();

    private Client(ClientId clientId, string firstName, string lastName, string email, string identityId)
    {
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentityId = identityId;
    }

    public ClientId ClientId { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string IdentityId { get; private set; }

    public IReadOnlyCollection<Order?> Orders => _orders.AsReadOnly();

    public IReadOnlyCollection<Address?> Addresses => _addresses.AsReadOnly();

    public void AddNewShippingAddress(string name, string street, int number, string city, string country = "AR")
    {
        _addresses.Add(Address.Create(name, street, number, city, country, false, true));
    }

    public void AddNewBillingAddress(string name, string street, int number, string city, string country = "AR")
    {
        _addresses.Add(Address.Create(name, street, number, city, country, true, false));
    }

    public static Client CreateUser(string firstName, string lastName, string email, string identityId)
    {
        return new Client(ClientId.CreateUnique(), firstName, lastName, email, identityId);
    }
}
