using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

public sealed class Vehicle : Entity
{
    private Vehicle()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int FabricationYear { get; private set; }
    public long Mileage { get; private set; }
    public string LicensePlate { get; private set; }
    public Guid OwnerId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid ManufacturerId { get; private set; }
    
}