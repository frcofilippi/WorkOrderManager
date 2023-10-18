
namespace WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;
public record CreateOrderRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<OrderLineRequest> Lines { get; set; }
}

public record OrderLineRequest(string Name, string Description);
