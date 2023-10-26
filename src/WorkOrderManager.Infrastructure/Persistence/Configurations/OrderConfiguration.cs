using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.Entities;
using WorkOrderManager.Domain.Orders.ValueObjects;

namespace WorkOrderManager.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                    .HasConversion(
                        id => id.Value,
                        value => OrderId.Create(value))
                    .ValueGeneratedNever();

            builder.OwnsMany(
                o => o.OrderLines,
                b =>
                {
                    b.ToTable("OrderLines");
                    b.WithOwner().HasForeignKey("OrderId");
                    b.HasKey(ol => ol.Id);
                    b.Property(ol => ol.Id)
                    .HasConversion(id => id.Value, val => OrderLineId.Create(val))
                    .ValueGeneratedNever()
                    .HasColumnName("OrderLineId");
                });
        }
    }
}