using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;


internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name).IsRequired().HasMaxLength(100);
        builder.Property(v => v.Description).HasMaxLength(500);
        builder.Property(v => v.FabricationYear).IsRequired();
        builder.Property(v => v.Mileage).IsRequired();
        builder.Property(v => v.LicensePlate).IsRequired().HasMaxLength(20);
        builder.Property(v => v.OwnerId).IsRequired();
        builder.Property(v => v.ManufacturerId).IsRequired();
       
        builder.HasMany(v => v.Maintenances)
            .WithOne(m => m.Vehicle)
            .HasForeignKey(m => m.VehicleId);
    }
}