using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

public sealed class VehicleCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
