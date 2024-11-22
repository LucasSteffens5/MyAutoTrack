using MediatR;
using MyAutoTrack.Common.Application.Authorization;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Users.Application.Users.GetUserPermissions;

namespace MyAutoTrack.Modules.Users.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}
