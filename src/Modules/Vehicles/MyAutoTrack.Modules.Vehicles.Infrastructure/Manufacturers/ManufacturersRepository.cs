using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Manufacturers;

public sealed class ManufacturersRepository(VehiclesDbContext context) : IManufacturersRepository
{
    public async Task<Manufacturer?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Manufacturers.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);


    public void Insert(Manufacturer manufacturer)
    {
        context.Manufacturers.Add(manufacturer);
    }
}