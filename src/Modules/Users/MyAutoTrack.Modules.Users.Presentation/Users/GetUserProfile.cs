using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Infrastructure.Authentication;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Users.Application.Users.GetUser;

namespace MyAutoTrack.Modules.Users.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/profile", async (ClaimsPrincipal claims, ISender sender) =>
            {
                Result<UserResponse> result = await sender.Send(new GetUserQuery(claims.GetUserId()));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetUser)
            .WithTags(Tags.Users);
    }
}
