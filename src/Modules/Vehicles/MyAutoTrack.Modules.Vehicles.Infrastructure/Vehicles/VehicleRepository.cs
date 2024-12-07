using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Vehicles;

internal sealed class VehicleRepository(VehiclesDbContext context) : IVehicleRepository
{
    public async Task<Vehicle?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);


    public void Insert(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }
}