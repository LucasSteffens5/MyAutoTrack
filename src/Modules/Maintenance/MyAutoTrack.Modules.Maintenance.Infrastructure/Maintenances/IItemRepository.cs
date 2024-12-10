using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;

public interface IItemRepository
{
    Task<Item?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Item item);
}