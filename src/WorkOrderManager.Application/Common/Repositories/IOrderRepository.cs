
namespace WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.ValueObjects;
public interface IOrderRepository
{
    IReadOnlyCollection<Order> Orders { get; }

    Task<Order> AddOrder(Order order);

    Task RemoveOrder(Order order);

    Task UpdateOrder(Order order);

    Task<Order?> GetOrderById(OrderId orderId);
}
