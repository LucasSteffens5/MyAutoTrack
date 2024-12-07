using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Vehicles.Application.Vehicles.GetVehicles;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Vehicles;

internal sealed class GetVehicles : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("vehicle", async ([FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<VehiclesResponse> result = await sender.Send(new GetVehiclesQuery(request.VehicleId));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetVehicles)
            .WithTags(Tags.Vehicles);
    }

    internal sealed class Request
    {
        public Guid VehicleId { get; init; }
    }
}