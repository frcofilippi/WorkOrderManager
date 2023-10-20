
namespace WorkOrderManager.Domain.Orders.ValueObjects;

using WorkOrderManager.Domain.Model;
public class ClientId : ValueObject
{
    public Guid Value { get; private set; }

    private ClientId(Guid id)
    {
        Value = id;
    }

    public static ClientId CreateUnique()
    {
        return new ClientId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }

    public static ClientId Create(Guid userJti)
    {
        return new ClientId(userJti);
    }
}