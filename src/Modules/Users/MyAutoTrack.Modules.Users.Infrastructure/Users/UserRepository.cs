using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Users.Domain.Users;
using MyAutoTrack.Modules.Users.Infrastructure.Database;

namespace MyAutoTrack.Modules.Users.Infrastructure.Users;

internal sealed class UserRepository(UsersDbContext context) : IUserRepository
{
    public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public void Insert(User user)
    {
        foreach (Role role in user.Roles)
        {
            context.Attach(role);
        }

        context.Users.Add(user);
    }
}
