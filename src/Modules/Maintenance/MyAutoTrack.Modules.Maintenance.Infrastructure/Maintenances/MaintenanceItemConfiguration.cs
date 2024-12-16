using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class MaintenanceItemConfiguration : IEntityTypeConfiguration<MaintenanceItem>
{
    public void Configure(EntityTypeBuilder<MaintenanceItem> builder)
    {
        builder.ToTable("maintenance_items");

        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.MaintenanceId).IsRequired();
        builder.Property(mi => mi.ItemId).IsRequired();
        builder.Property(mi => mi.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(mi => mi.Quantity).IsRequired();
        builder.Ignore(mi => mi.TotalPrice);

        builder.HasOne(mi => mi.Maintenance)
            .WithMany(m => m.MaintenanceItems)
            .HasForeignKey(mi => mi.MaintenanceId);

        builder.HasOne(mi => mi.Item)
            .WithMany(i => i.MaintenanceItems)
            .HasForeignKey(mi => mi.ItemId);
    }
}