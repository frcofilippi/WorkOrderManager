
namespace WorkOrderManager.Application.Orders.Commands;

using ErrorOr;

using MediatR;

using WorkOrderManager.Domain.Orders;

public record CreateOrderCommand : IRequest<ErrorOr<Order>>
{
    public string ClientName { get; set; }
    public List<OrderLineCommand> Lines { get; set; }
}

public record OrderLineCommand(string Name, string Description);
