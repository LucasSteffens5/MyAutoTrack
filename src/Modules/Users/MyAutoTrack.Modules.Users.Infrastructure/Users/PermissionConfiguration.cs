using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAutoTrack.Modules.Users.Domain.Users;

namespace MyAutoTrack.Modules.Users.Infrastructure.Users;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(p => p.Code);

        builder.Property(p => p.Code).HasMaxLength(100);

        builder.HasData(
            Permission.GetUser,
            Permission.ModifyUser); // TODO Aqui adicioanr mais permissoes para outros modulos

        builder
            .HasMany<Role>()
            .WithMany()
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("role_permissions");

                joinBuilder.HasData(
                    // Member permissions
                    CreateRolePermission(Role.Member, Permission.GetUser),
                  
                    // Admin permissions
                    CreateRolePermission(Role.Administrator, Permission.GetUser), //TODO Aqui adicionar mais roles para outros modulos
                    CreateRolePermission(Role.Administrator, Permission.ModifyUser));
            });
    }

    private static object CreateRolePermission(Role role, Permission permission)
    {
        return new
        {
            RoleName = role.Name,
            PermissionCode = permission.Code
        };
    }
}
