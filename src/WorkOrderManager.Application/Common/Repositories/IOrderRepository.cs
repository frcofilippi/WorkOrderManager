using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.ValueObjects;

namespace WorkOrderManager.Application.Common.Repositories;
public interface IOrderRepository
{
    Task<Order> AddOrder(Order order);

    Task RemoveOrder(Order order);

    Task UpdateOrder(Order order);

    Task<Order?> GetOrderById(OrderId orderId);
}
