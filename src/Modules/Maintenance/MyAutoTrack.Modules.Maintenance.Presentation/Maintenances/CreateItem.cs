using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateItem;

namespace MyAutoTrack.Modules.Maintenance.Presentation.Maintenances;

internal sealed class CreateItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("maintenances/item", async ([FromBody] Request request, [FromServices] ISender sender) =>
            {
                Result<Guid> result =
                    await sender.Send(new CreateItemCommand(request.Name, request.Type, request.Price,
                        request.Inventory));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.ModifyMaintenance)
            .WithTags(Tags.Maintenances);
    }

    internal sealed class Request
    {
        public string Name { get; init; }

        public string Type { get; init; }
        public decimal Price { get; init; }
        public long Inventory { get; init; }
    }
}