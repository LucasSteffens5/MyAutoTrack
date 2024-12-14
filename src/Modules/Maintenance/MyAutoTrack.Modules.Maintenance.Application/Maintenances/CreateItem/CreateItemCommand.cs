using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateItem;

public sealed record CreateItemCommand(string Name, string Type, decimal Price, long Inventory) : ICommand<Guid>;