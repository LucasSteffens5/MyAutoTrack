using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;

namespace MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateMaintenance;

public sealed record CreateMaintenanceCommand(
    Vehicle Vehicle,
    Guid VehicleId,
    MaintenanceStatus Status,
    long Mileage,
    decimal TotalPrice,
    string Description,
    IList<MaintenanceItem> MaintenanceItems) : ICommand<Guid>;