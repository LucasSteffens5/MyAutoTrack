using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Modules.Maintenance.Application.Abstractions.Data;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;
using MyAutoTrack.Modules.Maintenance.Presentation;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure;

public static class MaintenanceModule
{
    public static IServiceCollection AddMaintenanceModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddInfrastructure(configuration);
        
        services.AddEndpoints(PresentationMaintenanceAssemblyReference.Assembly);

        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MaintenanceDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Maintenance))
                .UseSnakeCaseNamingConvention());

         services.AddScoped<IVehicleRepository, VehicleRepository>();
         services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
         services.AddScoped<IItemRepository, ItemRepository>();
         services.AddScoped<IMaintenanceItemRepository, MaintenanceItemRepository>();
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MaintenanceDbContext>());
        
        // services.Configure<OutboxOptions>(configuration.GetSection("Maintenance:Outbox"));
        // services.ConfigureOptions<ConfigureProcessOutboxJob>();
        //
        // services.Configure<InboxOptions>(configuration.GetSection("Maintenance:Inbox"));
        //
        // services.ConfigureOptions<ConfigureProcessInboxJob>();
    }
}