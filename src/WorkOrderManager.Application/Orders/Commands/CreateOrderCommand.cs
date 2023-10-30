
namespace WorkOrderManager.Application.Orders.Commands;

using ErrorOr;

using MediatR;

using WorkOrderManager.Domain.Common;
using WorkOrderManager.Domain.Common.ValueObjects;

public record CreateOrderCommand : IRequest<ErrorOr<Order>>
{
    public string ClientName { get; set; }
    public List<OrderLineCommand> Lines { get; set; }
    public Address DeliveryAddress { get; set; }
    public Address BillingAddress { get; set; }
}

public record OrderLineCommand(string Name, string Description);
