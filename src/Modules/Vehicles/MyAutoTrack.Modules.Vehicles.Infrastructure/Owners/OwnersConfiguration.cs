using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Owners;

internal sealed class OwnersConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(200);
    }
}