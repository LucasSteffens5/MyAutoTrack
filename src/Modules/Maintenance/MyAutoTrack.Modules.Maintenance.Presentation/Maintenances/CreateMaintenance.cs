using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateMaintenance;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;
using MyAutoTrack.Modules.Maintenance.Domain.Vehicles;

namespace MyAutoTrack.Modules.Maintenance.Presentation.Maintenances;

public class CreateMaintenance : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("maintenances/maintenance", async ([FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<Guid> result =
                    await sender.Send(new CreateMaintenanceCommand(
                        request.Vehicle,
                        request.Vehicle.Id,
                        request.Status,
                        request.Mileage,
                        request.TotalPrice,
                        request.Description,
                        request.MaintenanceItems));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.ModifyMaintenance)
            .WithTags(Tags.Maintenances);
    }

    internal sealed class Request
    {
        public Vehicle Vehicle { get; init; }
        public MaintenanceStatus Status { get; init; }
        public long Mileage { get; init; }
        public string Description { get; init; }
        public decimal TotalPrice { get; init; }
        public IList<MaintenanceItem> MaintenanceItems { get; init; }
    }
}