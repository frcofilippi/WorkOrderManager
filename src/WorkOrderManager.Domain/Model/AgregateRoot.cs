
namespace WorkOrderManager.Domain.Model;

public abstract class AgregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    protected AgregateRoot(TId id) : base(id) { }
} 