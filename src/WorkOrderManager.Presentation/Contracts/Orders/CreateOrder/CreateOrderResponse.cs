
namespace WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;

public record CreateOrderResponse(string OrderId, string ClientName, string ClienId, DateTime CreationDate, List<OrderLineResponse> OrderLines, string BillingAddress, string ShippingAddress);

public record OrderLineResponse(string LineDescription, string LineName, string LineId);