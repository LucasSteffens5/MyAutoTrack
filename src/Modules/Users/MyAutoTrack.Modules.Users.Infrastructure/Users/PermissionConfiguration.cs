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
            Permission.ModifyUser,
            Permission.ModifyVehicles,
            Permission.GetVehicles,
            Permission.GetMaintenance,
            Permission.ModifyMaintenance); // TODO Aqui adicioanr mais permissoes para outros modulos

        builder
            .HasMany<Role>()
            .WithMany()
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("role_permissions");

                joinBuilder.HasData(
                    // Member permissions
                    CreateRolePermission(Role.Member, Permission.GetUser),
                    CreateRolePermission(Role.Member, Permission.ModifyVehicles),
                    CreateRolePermission(Role.Member, Permission.GetVehicles),
                    CreateRolePermission(Role.Member, Permission.GetMaintenance),
                    CreateRolePermission(Role.Member, Permission.ModifyMaintenance),
                  
                    // Admin permissions
                    CreateRolePermission(Role.Administrator, Permission.GetUser), 
                    CreateRolePermission(Role.Administrator, Permission.ModifyUser),
                    CreateRolePermission(Role.Administrator, Permission.ModifyVehicles),
                    CreateRolePermission(Role.Administrator, Permission.GetMaintenance),
                    CreateRolePermission(Role.Administrator, Permission.ModifyMaintenance),
                    CreateRolePermission(Role.Administrator, Permission.GetVehicles) //TODO Aqui adicionar mais roles para outros modulos
                    );
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
