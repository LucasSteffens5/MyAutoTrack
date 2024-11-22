using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Common.Infrastructure.Inbox;
using MyAutoTrack.Common.Infrastructure.Outbox;
using MyAutoTrack.Modules.Users.Application.Abstractions.Data;
using MyAutoTrack.Modules.Users.Domain.Users;
using MyAutoTrack.Modules.Users.Infrastructure.Users;

namespace MyAutoTrack.Modules.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration()); 
        
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}

