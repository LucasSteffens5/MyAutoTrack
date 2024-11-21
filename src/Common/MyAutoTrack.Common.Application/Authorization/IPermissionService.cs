using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Common.Application.Authorization;

public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}