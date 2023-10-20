
namespace WorkOrderManager.Infrastructure.Persistence.Repositories;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.ValueObjects;
public class OrderRepository : IOrderRepository
{
    private static readonly List<Order> _orders = new ();

    public IReadOnlyCollection<Order> Orders => _orders!.ToList();

    public async Task<Order> AddOrder(Order order)
    {
        _orders.Add(order);
        return await Task.FromResult(order);
    }

    public async Task<Order?> GetOrderById(OrderId orderId)
    {
        var order = await Task.FromResult(_orders!.FirstOrDefault(o => o.Id == orderId));
        return order;
    }

    public async Task RemoveOrder(Order order)
    {
       await Task.FromResult(_orders!.Remove(order));
    }

    public async Task UpdateOrder(Order order)
    {
        await Task.FromResult(1);
    }

}
