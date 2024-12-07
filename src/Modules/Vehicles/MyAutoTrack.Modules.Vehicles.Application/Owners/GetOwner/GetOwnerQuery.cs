using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.GetOwner;

public sealed record GetOwnerQuery(Guid OwnerId): IQuery<OwnerResponse>;