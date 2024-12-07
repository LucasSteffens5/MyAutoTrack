using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.CreateManufacturer;

public sealed record CreateManufacturerCommand (string Name): ICommand<Guid>;
