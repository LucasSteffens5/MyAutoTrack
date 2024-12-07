using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.CreateManufacturers;

public sealed record CreateManufacturersCommand (string Name): ICommand<Guid>;
