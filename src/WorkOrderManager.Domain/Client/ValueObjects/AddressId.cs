namespace WorkOrderManager.Domain.Clients.ValueObjects;

using WorkOrderManager.Domain.Model;

public class AddressId : ValueObject
{
     public Guid Value { get; private set; }

     private AddressId(Guid id)
    {
        Value = id;
    }

     public static AddressId CreateUnique()
    {
        return new AddressId(Guid.NewGuid());
    }

     public static AddressId Create(Guid userJti) => new AddressId(userJti);

     protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }
}