using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.CreateVehicle;

public sealed record CreateVehicleCommand(
    string Name,
    string Description,
    int FabricationYear,
    long Mileage,
    string LicensePlate,
    Guid OwnerId,
    Guid ManufacturerId) : ICommand<Guid>;