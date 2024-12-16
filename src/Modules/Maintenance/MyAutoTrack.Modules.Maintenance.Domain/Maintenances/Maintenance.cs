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

    public static Maintenance Create(Vehicle Vehicle, Guid VehicleId, MaintenanceStatus Status, long Mileage,
        decimal TotalPrice, string Description, IList<MaintenanceItem> MaintenanceItems)
    {
        return new Maintenance
        {
            Id = Guid.NewGuid(),
            Vehicle = Vehicle,
            VehicleId = VehicleId,
            Status = Status,
            Mileage = Mileage,
            TotalPrice = TotalPrice,
            Description = Description,
            StartsAtUtc = DateTime.UtcNow,
            MaintenanceItems = MaintenanceItems
        };
    }
}