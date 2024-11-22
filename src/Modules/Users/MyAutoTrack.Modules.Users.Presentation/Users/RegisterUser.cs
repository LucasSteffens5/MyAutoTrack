using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Common.Presentation.Results;
using MyAutoTrack.Modules.Users.Application.Users.RegisterUser;

namespace MyAutoTrack.Modules.Users.Presentation.Users;

internal sealed class RegisterUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (Request request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new RegisterUserCommand(
                    request.Email,
                    request.Password,
                    request.FirstName,
                    request.LastName));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .AllowAnonymous()
            .WithTags(Tags.Users);
    }

    internal sealed class Request
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}
