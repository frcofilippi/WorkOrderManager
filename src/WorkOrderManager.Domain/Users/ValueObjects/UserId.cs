using WorkOrderManager.Domain.Model;

namespace WorkOrderManager.Domain.Users.ValueObjects;
public class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEquialityComponents()
    {
        yield return Value;
    }

    public static UserId Create(Guid guid)
    {
        return new UserId(guid);
    }
}
