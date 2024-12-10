using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
        builder.Property(i => i.Type).IsRequired().HasMaxLength(50);
        builder.Property(i => i.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(i => i.Inventory).IsRequired();
       
        builder.HasMany(i => i.MaintenanceItems)
            .WithOne(mi => mi.Item)
            .HasForeignKey(mi => mi.ItemId);
    }
}