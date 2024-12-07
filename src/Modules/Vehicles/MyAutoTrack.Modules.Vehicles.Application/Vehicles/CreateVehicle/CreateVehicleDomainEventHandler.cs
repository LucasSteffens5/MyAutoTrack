using MediatR;
using MyAutoTrack.Common.Application.EventBus;
using MyAutoTrack.Common.Application.Exceptions;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Application.Vehicles.GetVehicles;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;
using MyAutoTrack.Modules.Vehicles.IntegrationEvents;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleDomainEventHandler(ISender sender, IEventBus bus)
    : DomainEventHandler<VehicleCreatedDomainEvent>
{
    public override async Task Handle(VehicleCreatedDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        Result<VehiclesResponse> result =
            await sender.Send(new GetVehiclesQuery(domainEvent.VehicleId), cancellationToken);

        if (result.IsFailure)
        {
            throw new MyAutoTrackException(nameof(GetVehiclesQuery), result.Error);
        }

        await bus.PublishAsync(
            new CreateVehicleIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                result.Value.Id,
                result.Value.Name,
                result.Value.Description,
                result.Value.FabricationYear,
                result.Value.Mileage,
                result.Value.LicensePlate,
                result.Value.OwnerId,
                result.Value.ManufacturerId),
            cancellationToken);
    }
}