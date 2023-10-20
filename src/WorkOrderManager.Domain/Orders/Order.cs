namespace WorkOrderManager.Domain.Orders;

using WorkOrderManager.Domain.Model;
using WorkOrderManager.Domain.Orders.Entities;
using WorkOrderManager.Domain.Orders.ValueObjects;
public class Order : AgregateRoot<OrderId>
{
    private readonly List<OrderLine> _lines = new ();

    private Order(OrderId id, DateTime creationDate, ClientId clientId, string clientName)
        : base(id)
    {
        CreationDate = creationDate;
        ClientName = clientName;
        ClientId = clientId;
    }

    public DateTime CreationDate { get; private set; }

    public string ClientName { get; private set; }

    public ClientId ClientId { get; private set; }

    public string ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> OrderLines => _lines.ToList();

    public void AddLine(OrderLine line)
    {
        _lines.Add(line);
    }

    public static Order CreateOrder(ClientId clientId, string clientName)
    {
        var order = new Order(OrderId.CreateUnique(), DateTime.UtcNow, clientId, clientName);
        return order;
    }

}