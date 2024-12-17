using MediatR;
using MyAutoTrack.Common.Application.EventBus;
using MyAutoTrack.Common.Application.Exceptions;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Users.IntegrationEvents;
using MyAutoTrack.Modules.Vehicles.Application.Owners.CreateOwner;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Owners;

internal sealed class UserRegisteredIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<UserRegisteredIntegrationEvent>
{
    public override async Task Handle(
        UserRegisteredIntegrationEvent integrationEvent,
        CancellationToken cancellationToken = default)
    {
        Result result = await sender.Send(
            new CreateOwnerCommand(
                $"{integrationEvent.FirstName} {integrationEvent.LastName}",
                integrationEvent.UserId
                ),
            cancellationToken);

        if (result.IsFailure)
        {
            throw new MyAutoTrackException(nameof(CreateOwnerCommand), result.Error);
        }
    }
}