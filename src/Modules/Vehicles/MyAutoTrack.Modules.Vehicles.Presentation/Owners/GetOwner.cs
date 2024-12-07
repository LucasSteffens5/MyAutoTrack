using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Vehicles.Application.Owners.GetOwner;

namespace MyAutoTrack.Modules.Vehicles.Presentation.Owners;

internal sealed class GetOwner : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("vehicles/owner", async ([FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<OwnerResponse> result = await sender.Send(new GetOwnerQuery(request.OwnerId));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetVehicles)
            .WithTags(Tags.Vehicles);
    }

    internal sealed class Request
    {
        public Guid OwnerId { get; init; }
    }
}