using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;

internal sealed class VehicleRepository(MaintenanceDbContext context) : IVehicleRepository
{
    public async Task<Vehicle?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);


    public void Insert(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }
}