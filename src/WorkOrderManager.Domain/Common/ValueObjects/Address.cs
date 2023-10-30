using WorkOrderManager.Domain.Model;

namespace WorkOrderManager.Domain.Common.ValueObjects;

public class Address : ValueObject
{

    private Address(){}

    private Address(string street, int number, string city, string country)
    {
        Street = street;
        Number = number;
        City = city;
        Country = country;
    }

    public string Street { get; private set; }

    public int Number { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; } = "AR";

    public string FullAddress => $"{Street}, {Number}, {City}, {Country}";

    public static Address CreateNew(string street, int number, string city, string country)
    {
        return new Address(street, number, city, country);
    }

    public static Address ParseAddressFromFullString(string address)
    {
        var addressParts = address.Split(',');
        return new Address(addressParts[0], int.Parse(addressParts[1]), addressParts[2], addressParts[3]);
    }

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Street;
        yield return Number;
        yield return City;
        yield return Country;
    }
}