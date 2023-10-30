namespace WorkOrderManager.Domain.Common;

using WorkOrderManager.Domain.Model;
using WorkOrderManager.Domain.Common.Entities;
using WorkOrderManager.Domain.Common.ValueObjects;
public class Order : AgregateRoot<OrderId>
{
    private readonly List<OrderLine> _orderLines = new();

    private Order() : base(default) { }

    private Order(OrderId id, DateTime creationDate, ClientId clientId, string clientName, Address deliveryAddress, Address billingAddress)
        : base(id)
    {
        CreationDate = creationDate;
        ClientName = clientName;
        ClientId = clientId;
        DeliveryAddress = deliveryAddress;
        BillingAddress = billingAddress;
    }

    public DateTime CreationDate { get; private set; }

    public string ClientName { get; private set; }

    public ClientId ClientId { get; private set; }

    public Address DeliveryAddress { get; private set; }

    public Address BillingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> OrderLines => _orderLines.ToList();

    public void AddLine(OrderLine line)
    {
        _orderLines.Add(line);
    }

    public static Order CreateOrder(ClientId clientId, string clientName, Address delivery, Address billing)
    {
        var order = new Order(OrderId.CreateUnique(), DateTime.UtcNow, clientId, clientName, delivery, billing);
        return order;
    }

}
