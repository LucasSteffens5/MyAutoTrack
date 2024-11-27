namespace MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

public interface IManufacturersRepository
{
    Task<Manufacturer?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Manufacturer manufacturer);
}