using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Common.Infrastructure.Inbox;
using MyAutoTrack.Common.Infrastructure.Outbox;
using MyAutoTrack.Modules.Maintenance.Application.Abstractions.Data;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Database;

public class MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Maintenance> Maintenances { get; set; }
    public DbSet<MaintenanceItem> MaintenanceItems { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Maintenance);
        
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration()); 
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new MaintenanceConfiguration());
        modelBuilder.ApplyConfiguration(new MaintenanceItemConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }
}