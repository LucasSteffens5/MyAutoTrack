using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyAutoTrack.Common.Application.EventBus;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Modules.Maintenance.Application;
using MyAutoTrack.Modules.Maintenance.Application.Abstractions.Data;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Inbox;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Maintenances;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Outbox;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Vehicles;
using MyAutoTrack.Modules.Maintenance.Presentation;

namespace MyAutoTrack.Modules.Maintenance.Infrastructure;

public static class MaintenanceModule
{
    public static IServiceCollection AddMaintenanceModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        
        services.AddDomainEventHandlers();
        services.AddIntegrationEventHandlers();
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
        
        services.Configure<OutboxOptions>(configuration.GetSection("Maintenance:Outbox"));
        services.ConfigureOptions<ConfigureProcessOutboxJob>();
        
        services.Configure<InboxOptions>(configuration.GetSection("Maintenance:Inbox"));
        
        services.ConfigureOptions<ConfigureProcessInboxJob>();
    }
    
    private static void AddDomainEventHandlers(this IServiceCollection services)
    {
        Type[] domainEventHandlers = Application.AssemblyReference.Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler)))
            .ToArray();

        foreach (Type domainEventHandler in domainEventHandlers)
        {
            services.TryAddScoped(domainEventHandler);

            Type domainEvent = domainEventHandler
                .GetInterfaces()
                .Single(i => i.IsGenericType)
                .GetGenericArguments()
                .Single();

            Type closedIdempotentHandler = typeof(IdempotentDomainEventHandler<>).MakeGenericType(domainEvent);

            services.Decorate(domainEventHandler, closedIdempotentHandler);
        }
    }
    
    private static void AddIntegrationEventHandlers(this IServiceCollection services)
    {
        Type[] integrationEventHandlers = AssemblyReference.Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IIntegrationEventHandler)))
            .ToArray();

        foreach (Type integrationEventHandler in integrationEventHandlers)
        {
            services.TryAddScoped(integrationEventHandler);

            Type integrationEvent = integrationEventHandler
                .GetInterfaces()
                .Single(i => i.IsGenericType)
                .GetGenericArguments()
                .Single();

            Type closedIdempotentHandler =
                typeof(IdempotentIntegrationEventHandler<>).MakeGenericType(integrationEvent);

            services.Decorate(integrationEventHandler, closedIdempotentHandler);
        }
    }
}