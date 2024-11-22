using MyAutoTrack.Common.Application.Authorization;
using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
