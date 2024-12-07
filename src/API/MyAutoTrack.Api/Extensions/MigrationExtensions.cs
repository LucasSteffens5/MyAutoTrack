using Microsoft.EntityFrameworkCore;
using MyAutoTrack.Modules.Users.Infrastructure.Database;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;

namespace MyAutoTrack.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<UsersDbContext>(scope); 
        ApplyMigration<VehiclesDbContext>(scope);
        // TODO: Aqui adionar outros db contexts dos modulos a serem desenvolvidos
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
