using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Vehicles.Application.Manufacturers.GetManufacturer;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Manufacturers;

internal sealed class GetManufacturer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("vehicles/manufacturer", async ([FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<ManufacturerResponse> result = await sender.Send(new GetManufacturerQuery(request.ManufacturerId));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetVehicles)
            .WithTags(Tags.Vehicles);
    }

    internal sealed class Request
    {
        public Guid ManufacturerId { get; init; }
    }
}