
using WorkOrderManager.Domain.Common.ValueObjects;

namespace WorkOrderManager.Presentation.Contracts.Orders.GetOrder;

public record GetOrderByIdRequest(string Id);

public record GetOrderByIdResponse(DateTime CreationDate, string ClientName, string[] OrderLines, Address ShippingAddress, Address BillingAddress);