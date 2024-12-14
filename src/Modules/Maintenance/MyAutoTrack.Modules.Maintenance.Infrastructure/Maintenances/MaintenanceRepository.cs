using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

internal sealed class MaintenanceRepository(MaintenanceDbContext context) : IMaintenanceRepository
{
    public async Task<Domain.Maintenances.Maintenance?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Maintenances.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);


    public void Insert(Domain.Maintenances.Maintenance maintenance)
    {
        context.Maintenances.Add(maintenance);
    }
}