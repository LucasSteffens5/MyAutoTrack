using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

public sealed class MaintenanceItem : Entity
{
    private MaintenanceItem()
    {
    }

    
    public Guid Id { get; set; }
    public Guid MaintenanceId { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;
    
    public Maintenance Maintenance { get; set; }
}