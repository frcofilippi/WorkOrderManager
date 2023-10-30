namespace WorkOrderManager.Domain.Clients.Entities;

using WorkOrderManager.Domain.Clients.ValueObjects;
using WorkOrderManager.Domain.Common.ValueObjects;
using WorkOrderManager.Domain.Model;

public class ClientAddress : Entity<AddressId>
{
    private ClientAddress()
        : base(default)
    {
    }

    private ClientAddress(AddressId id, string addressName, Address address, bool isDefaultAddress, bool isBilling, bool isShipping)
    : base(id)
    {
        AddressName = addressName;
        IsBilling = isBilling;
        IsShipping = isShipping;
        IsDefaultAddress = isDefaultAddress;
        Address = address;
    }

    public string AddressName { get; private set; }

    public Address Address { get; private set; }

    public bool IsDefaultAddress { get; private set; }

    public bool IsShipping { get; private set; }

    public bool IsBilling { get; private set; }

    public static ClientAddress Create(string name, string street, int number, string city, string country, bool isBilling, bool isShipping, bool isDefault)
    {
        var address = Address.CreateNew(street, number, city, country);
        return new ClientAddress(AddressId.CreateUnique(), name, address, isDefault, isBilling, isShipping);
    }
}
