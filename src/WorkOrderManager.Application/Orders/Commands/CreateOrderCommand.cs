
namespace WorkOrderManager.Application.Orders.Commands;

using MediatR;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.Entities;

public record CreateOrderCommand : IRequest<Order>
{
    public string ClientName { get; set; }
    public List<OrderLineCommand> Lines { get; set; }
}

public record OrderLineCommand(string Name, string Description);
public class CreateOrderCommandHanlder : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHanlder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.CreateOrder(request.ClientName);
        foreach (var line in request.Lines)
        {
            order.AddLine(OrderLine.CreateItem(line.Name, line.Description));
        }
        var result = await _orderRepository.AddOrder(order);
        return result;
    }
}
