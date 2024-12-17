using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyAutoTrack.Common.Application.EventBus;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Infrastructure.Outbox;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Modules.Users.IntegrationEvents;
using MyAutoTrack.Modules.Vehicles.Application;
using MyAutoTrack.Modules.Vehicles.Application.Abstractions.Data;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Inbox;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Outbox;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Owners;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Vehicles;
using MyAutoTrack.Modules.Vehicles.Presentation;

namespace MyAutoTrack.Modules.Vehicles.Infrastructure;

public static class VehiclesModule
{
    public static IServiceCollection AddVehiclesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDomainEventHandlers();
        
        services.AddIntegrationEventHandlers();

        services.AddInfrastructure(configuration);
        
        services.AddEndpoints(PresentationVehiclesAssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehiclesDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Vehicles))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));

        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IOwnersRepository, OwnersRepository>();
        services.AddScoped<IManufacturersRepository, ManufacturersRepository>();
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<VehiclesDbContext>());
        
        services.Configure<OutboxOptions>(configuration.GetSection("Vehicles:Outbox"));

        services.ConfigureOptions<ConfigureProcessOutboxJob>();

        services.Configure<InboxOptions>(configuration.GetSection("Vehicles:Inbox"));

        services.ConfigureOptions<ConfigureProcessInboxJob>();
    }
    
    private static void AddIntegrationEventHandlers(this IServiceCollection services)
    {
        Type[] integrationEventHandlers = PresentationVehiclesAssemblyReference.Assembly
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
    
    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator, string instanceId)
    {
        registrationConfigurator.AddConsumer<IntegrationEventConsumer<UserRegisteredIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);
    }
}