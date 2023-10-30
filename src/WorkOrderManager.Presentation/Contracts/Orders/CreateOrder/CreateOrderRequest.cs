
namespace WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;
public record CreateOrderRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<OrderLineRequest> Lines { get; set; }
    public DeliveryAddressRequest DeliveryAddress { get; set; }
    public BillingAddressRequest BillingAddress { get; set; }
}

public record OrderLineRequest(string Name, string Description);

public record DeliveryAddressRequest(
    string Street, int Number, string City, string Country);

public record BillingAddressRequest(
    string Street, int Number, string City, string Country);