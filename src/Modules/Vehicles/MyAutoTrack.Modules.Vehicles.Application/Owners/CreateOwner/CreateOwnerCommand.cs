using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.CreateOwner;

public sealed record CreateOwnerCommand(string Name): ICommand<Guid>;