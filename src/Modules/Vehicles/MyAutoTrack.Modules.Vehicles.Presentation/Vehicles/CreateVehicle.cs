using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Vehicles.Application.Vehicles.CreateVehicle;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Vehicles;

internal sealed class CreateVehicle : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("vehicles", async (Request request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateVehicleCommand(
                    request.Name,
                    request.Description,
                    request.FabricationYear, 
                    request.Mileage,
                    request.LicensePlate,
                    request.OwnerId,
                    request.ManufacturerId
                ));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.ModifyVehicles)
            .WithTags(Tags.Vehicles);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int FabricationYear { get; init; }
        public long Mileage { get; init; }
        public string LicensePlate { get; init; }
        public Guid OwnerId { get; init; }
        public Guid ManufacturerId { get; init; }
    }
}