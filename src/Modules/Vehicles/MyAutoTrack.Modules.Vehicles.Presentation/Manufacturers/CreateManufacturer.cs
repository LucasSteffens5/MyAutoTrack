using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Vehicles.Application.Manufacturers.CreateManufacturer;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Manufacturers;

internal sealed class CreateManufacturer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("vehicles/manufacturer", async ( [FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateManufacturerCommand(request.Name));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.ModifyVehicles)
            .WithTags(Tags.Vehicles);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}