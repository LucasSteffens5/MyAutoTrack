using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Vehicle vehicle);
}  