using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class MaintenanceConfiguration : IEntityTypeConfiguration<Domain.Maintenances.Maintenance>
{
    public void Configure(EntityTypeBuilder<Domain.Maintenances.Maintenance> builder)
    {
        builder.ToTable("maintenances");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.VehicleId).IsRequired();
        builder.Property(m => m.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(m => m.Status).IsRequired();
        builder.Property(m => m.StartsAtUtc).IsRequired();
        builder.Property(m => m.EndsAtUtc);
        builder.Property(m => m.Mileage).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(500);

        builder.HasOne(m => m.Vehicle)
            .WithMany(v => v.Maintenances)
            .HasForeignKey(m => m.VehicleId);

        builder.HasMany(m => m.MaintenanceItems)
            .WithOne(mi => mi.Maintenance)
            .HasForeignKey(mi => mi.MaintenanceId);
    }
}