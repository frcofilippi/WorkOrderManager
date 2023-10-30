using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkOrderManager.Domain.Clients.Entities;
using WorkOrderManager.Domain.Clients.ValueObjects;

namespace WorkOrderManager.Infrastructure.Persistence.Configurations;

public class ClientAddressConfiguration : IEntityTypeConfiguration<ClientAddress>
{
    public void Configure(EntityTypeBuilder<ClientAddress> builder)
    {
        builder.ToTable("ClientAddresses");
        builder.HasKey(ca => ca.Id);
        builder.Property(ca => ca.Id)
        .HasConversion(
            id => id.Value, value => AddressId.Create(value))
        .HasColumnName("AddressId");
        builder.OwnsOne(ca => ca.Address, navBuilder =>
        {
            navBuilder.Property(address => address.Street).HasColumnName("Street");
            navBuilder.Property(address => address.Number).HasColumnName("StreetNumber");
            navBuilder.Property(address => address.City).HasColumnName("City");
            navBuilder.Property(address => address.Country).HasColumnName("Country");
        });
        builder.Property(ca => ca.AddressName);
        builder.Property(ca => ca.IsBilling);
        builder.Property(ca => ca.IsShipping);
        builder.Property(ca => ca.IsDefaultAddress);

    }
}
