using WorkOrderManager.Domain.Model;

namespace WorkOrderManager.Domain.Orders.ValueObjects;

public class OrderLineId : ValueObject
{
    public Guid Value { get; private set; }

    private OrderLineId(Guid id)
    {
        Value = id;
    }

    public static OrderLineId CreateUnique()
    {
        return new OrderLineId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }

    public static OrderLineId Create(Guid val)
    {
        return new OrderLineId(val);
    }
}

