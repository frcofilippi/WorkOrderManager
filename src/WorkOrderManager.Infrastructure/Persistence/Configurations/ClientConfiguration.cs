using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Clients.ValueObjects;
using WorkOrderManager.Domain.Orders.ValueObjects;

namespace WorkOrderManager.Infrastructure.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.ClientId);
        builder.Property(c => c.ClientId)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => ClientId.Create(value))
                .HasColumnName("ClientId");
        builder.Property(c => c.FirstName).HasMaxLength(200);
        builder.Property(c => c.LastName).HasMaxLength(200);

        builder.HasMany(c => c.Orders)
                .WithOne()
                .HasForeignKey(o => o.ClientId);

        builder.OwnsMany(c => c.Addresses, ab =>
        {
            ab.ToTable("ClientAddresses");
            ab.HasKey(a => a.Id);
            ab.Property(a => a.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => AddressId.Create(value))
                    .HasColumnName("AddressId");
            ab.WithOwner().HasForeignKey("ClientId");
        });
    }
}