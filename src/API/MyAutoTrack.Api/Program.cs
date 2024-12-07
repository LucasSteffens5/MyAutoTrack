using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MyAutoTrack.Api.Extensions;
using MyAutoTrack.Api.Middleware;
using MyAutoTrack.Api.OpenTelemetry;
using MyAutoTrack.Common.Application;
using MyAutoTrack.Common.Infrastructure;
using MyAutoTrack.Common.Infrastructure.Configuration;
using MyAutoTrack.Common.Infrastructure.EventBus;
using MyAutoTrack.Common.Presentation.Endpoints;
using MyAutoTrack.Modules.Users.Infrastructure;
using MyAutoTrack.Modules.Vehicles.Infrastructure;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies =
[
    MyAutoTrack.Modules.Users.Application.AssemblyReference.Assembly,
    MyAutoTrack.Modules.Vehicles.Application.AssemblyReference.Assembly
];

builder.Services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");
var rabbitMqSettings = new RabbitMqSettings(builder.Configuration.GetConnectionStringOrThrow("Queue"));

builder.Services.AddInfrastructure(
    DiagnosticsConfig.ServiceName,
    [
    ],
    rabbitMqSettings,
    databaseConnectionString,
    redisConnectionString);

Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddRabbitMQ(rabbitConnectionString: rabbitMqSettings.Host)
    .AddKeyCloak(keyCloakHealthUrl);

builder.Configuration
    .AddModuleConfiguration([
        "users", "vehicles"
    ]); // TODO: Adicionar as configurações dos modulos conforme for desenvolvendo

builder.Services.AddUsersModule(builder.Configuration);

builder.Services.AddVehiclesModule(builder.Configuration); // TODO: Adicionar os modulos conforme for desenvolvendo

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseLogContextTraceLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

app.Run();

namespace MyAutoTrack.Api
{
    public class Program;
}