
namespace WorkOrderManager.Domain.Orders.Entities;

using WorkOrderManager.Domain.Model;
using WorkOrderManager.Domain.Orders.ValueObjects;
public class OrderLine : Entity<OrderLineId>
{
    private OrderLine(OrderLineId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public static OrderLine CreateItem(string name, string desc)
    {
        return new OrderLine(OrderLineId.CreateUnique(), name, desc);
    }
}
