using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenance;

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

}