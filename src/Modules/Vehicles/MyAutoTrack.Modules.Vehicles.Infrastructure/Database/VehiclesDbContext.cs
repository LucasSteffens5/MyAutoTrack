
using MyAutoTrack.Modules.Vehicles.Application.Abstractions.Data;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Common.Infrastructure.Inbox;
using MyAutoTrack.Common.Infrastructure.Outbox;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Owners;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Vehicles;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Database;

public sealed class VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Vehicle> Vehicles { get; set; }

     internal DbSet<Manufacturer> Manufacturers { get; set; }
    
     internal DbSet<Owner> Owners { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Vehicles);
        
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration()); 

        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new OwnersConfiguration());
    }
}