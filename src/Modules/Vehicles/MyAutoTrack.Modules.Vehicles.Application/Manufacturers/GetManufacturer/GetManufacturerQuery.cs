using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.GetManufacturer;

public sealed record GetManufacturerQuery(Guid ManufactureId) : IQuery<ManufacturerResponse>;
