using MyAutoTrack.Common.Application.Messaging;

namespace MyAutoTrack.Modules.Users.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
