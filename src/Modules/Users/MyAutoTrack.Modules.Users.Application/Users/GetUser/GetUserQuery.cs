using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
