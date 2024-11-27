using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;

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
    public Guid ManufacturerId { get; private set; }

    public static Result<Vehicle> Create(
        Owner owner,
        Manufacturer manufacturer, string name, string description, int fabricationYear, long mileage,
        string licensePlate)
    {
        var vehicle = new Vehicle
        {
            OwnerId = owner.Id,
            ManufacturerId = manufacturer.Id,
            Name = name,
            Description = description,
            FabricationYear = fabricationYear,
            LicensePlate = licensePlate,
            Mileage = mileage,
            Id = Guid.NewGuid()
        };

        vehicle.Raise(new VehicleCreatedDomainEvent(vehicle.Id));

        return vehicle;
    }
}