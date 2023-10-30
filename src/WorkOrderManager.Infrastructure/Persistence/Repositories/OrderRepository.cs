using System.Security.Cryptography.X509Certificates;

using Microsoft.EntityFrameworkCore;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Domain.Common;
using WorkOrderManager.Domain.Common.Entities;
using WorkOrderManager.Domain.Common.ValueObjects;

namespace WorkOrderManager.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> AddOrder(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> GetOrderById(OrderId orderId)
    {
        return await _dbContext.Orders
                        .Include(o => o.OrderLines)
                        .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task RemoveOrder(Order order)
    {
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateOrder(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }

}
