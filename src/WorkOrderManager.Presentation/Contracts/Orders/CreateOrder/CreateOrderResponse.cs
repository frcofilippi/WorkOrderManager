
namespace WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;

public record CreateOrderResponse(string OrderId, string ClientName, DateTime CreationDate, List<OrderLineResponse> OrderLines);

public record OrderLineResponse(string LineDescription, string LineName, string LineId);