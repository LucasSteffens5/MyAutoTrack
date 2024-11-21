using Microsoft.AspNetCore.Routing;

namespace MyAutoTrack.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
