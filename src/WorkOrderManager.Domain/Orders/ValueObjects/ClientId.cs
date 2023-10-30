namespace WorkOrderManager.Domain.Common.ValueObjects;

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

    public static ClientId Create(Guid userJti) => new ClientId(userJti);

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }
}