using MyAutoTrack.Common.Application.EventBus;

namespace MyAutoTrack.Modules.Vehicles.IntegrationEvents;

public sealed class CreateVehicleIntegrationEvent(
    Guid id,
    DateTime occurredOnUtc,
    Guid VehicleId,
    string Name,
    string Description,
    int FabricationYear,
    long Mileage,
    string LicensePlate,
    Guid OwnerId,
    Guid ManufacturerId) : IntegrationEvent(id, occurredOnUtc)
{
}