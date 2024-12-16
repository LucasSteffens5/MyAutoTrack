using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class ItemRepository(MaintenanceDbContext context) : IItemRepository
{
    public async Task<Item?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Items.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);
    
    public void Insert(Item maintenance)
    {
        context.Items.Add(maintenance);
    }
}