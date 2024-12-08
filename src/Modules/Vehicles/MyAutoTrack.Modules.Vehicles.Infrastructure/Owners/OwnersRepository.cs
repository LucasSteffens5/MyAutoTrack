using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Owners;

public class OwnersRepository(VehiclesDbContext context) : IOwnersRepository
{
    public async Task<Owner?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Owners.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);


    public void Insert(Owner owner)
    {
        context.Owners.Add(owner);
    }
    
    public void Update(Owner owner)
    {
        context.Owners.Update(owner);
    }
}