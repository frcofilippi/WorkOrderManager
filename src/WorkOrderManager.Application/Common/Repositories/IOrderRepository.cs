using WorkOrderManager.Domain.Common;
using WorkOrderManager.Domain.Common.ValueObjects;

namespace WorkOrderManager.Application.Common.Repositories;
public interface IOrderRepository
{
    Task<Order> AddOrder(Order order);

    Task RemoveOrder(Order order);

    Task UpdateOrder(Order order);

    Task<Order?> GetOrderById(OrderId orderId);
}
