using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

public sealed class Maintenance : Entity
{
    private Maintenance()
    {
        
    }

    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public decimal TotalPrice { get; set; }
    public MaintenanceStatus Status { get; set; }
    public DateTime StartsAtUtc { get; private set; }
    public DateTime? EndsAtUtc { get; private set; }
    public long Mileage { get; private set; }
    public string Description { get; private set; }

    public ICollection<MaintenanceItem> MaintenanceItems { get; set; }
    public Vehicle Vehicle { get; set; }
}