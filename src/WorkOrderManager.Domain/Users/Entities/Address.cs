namespace WorkOrderManager.Domain.Clients.Entities;

using WorkOrderManager.Domain.Clients.ValueObjects;
using WorkOrderManager.Domain.Model;

public class Address : Entity<AddressId>
{
    private Address(AddressId id, string name, string street, int streetNumber, string city, string country, bool isBilling, bool isShipping)
    : base(id)
    {
        Name = name;
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        Country = country;
        IsActive = true;
        IsBilling = isBilling;
        IsShipping = isShipping;
    }

    public string Name { get; private set; }

    public string Street { get; private set; }

    public int StreetNumber { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsShipping { get; private set; }

    public bool IsBilling { get; private set; }

    public static Address Create(string name, string street, int number, string city, string country, bool isBilling, bool isShipping)
    {
        return new Address(AddressId.CreateUnique(), name, street, number, city, country, isBilling, isShipping);
    }
}
