namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

public interface IMaintenanceItemRepository
{
    Task<MaintenanceItem?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(MaintenanceItem maintenanceItem);
}