using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

public interface IMaintenanceItemRepository
{
    Task<MaintenanceItem?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(MaintenanceItem maintenanceItem);
}