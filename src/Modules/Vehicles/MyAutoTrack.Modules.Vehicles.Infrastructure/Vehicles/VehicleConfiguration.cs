using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Vehicles;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasOne<Manufacturer>().WithMany().HasForeignKey(t => t.ManufacturerId);
        builder.HasOne<Owner>().WithMany().HasForeignKey(t => t.OwnerId);
    }
}