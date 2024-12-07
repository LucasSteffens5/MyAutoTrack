namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.GetVehicles;

public sealed record VehiclesResponse(
    Guid Id,
    string Name,
    string Description,
    int FabricationYear,
    long Mileage,
    string LicensePlate,
    Guid OwnerId,
    Guid ManufacturerId
);