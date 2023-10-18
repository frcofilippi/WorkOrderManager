using WorkOrderManager.Domain.Model;

namespace WorkOrderManager.Domain.Orders.ValueObjects;
public class OrderId : ValueObject
{
    public Guid Value { get; private set; }

    private OrderId(Guid id)
    {
        Value = id;
    }

    public static OrderId CreateUnique()
    {
        return new OrderId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }

    public static OrderId Create(Guid guid)
    {
        return new OrderId(guid);
    }
}
