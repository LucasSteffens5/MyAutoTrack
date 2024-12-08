using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenance;

public sealed class MaintenanceItem : Entity
{
    private MaintenanceItem()
    {
    }

    public Guid Id { get; set; }
    public Guid MaintenanceId { get; set; }
    public Guid ItemId { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;
}