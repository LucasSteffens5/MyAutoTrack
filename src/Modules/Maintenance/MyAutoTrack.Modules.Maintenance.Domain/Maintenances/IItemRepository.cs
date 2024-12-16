namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

public interface IItemRepository
{
    Task<Item?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Item item);
}