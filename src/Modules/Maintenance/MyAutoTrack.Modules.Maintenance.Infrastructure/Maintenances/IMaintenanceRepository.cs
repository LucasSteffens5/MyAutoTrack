namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

public interface IMaintenanceRepository
{
    Task<Domain.Maintenances.Maintenance?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Domain.Maintenances.Maintenance maintenance);
}