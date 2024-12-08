namespace MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Vehicle vehicle);

    public void Update(Vehicle vehicle);
}