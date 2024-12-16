using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class MaintenanceItemRepository(MaintenanceDbContext context) : IMaintenanceItemRepository
{
    public async Task<MaintenanceItem?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.MaintenanceItems.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);

    public void Insert(MaintenanceItem maintenanceItem)
    {
        context.MaintenanceItems.Add(maintenanceItem);
    }
}