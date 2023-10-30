using System.Reflection;

using Microsoft.EntityFrameworkCore;

using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Clients.Entities;
using WorkOrderManager.Domain.Common;

namespace WorkOrderManager.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<ClientAddress> ClientAddresses => Set<ClientAddress>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}