using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.GetVehicles;

public sealed record GetVehiclesQuery(Guid VehicleId) : IQuery<VehiclesResponse>;