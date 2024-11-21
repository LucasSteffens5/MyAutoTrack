namespace MyAutoTrack.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected const string UsersNamespace = "MyAutoTrack.Modules.Users";
    protected const string UsersIntegrationEventsNamespace = "MyAutoTrack.Modules.Users.IntegrationEvents";

    protected const string VehiclesNamespace = "MyAutoTrack.Modules.Vehicles";
    protected const string VehiclesIntegrationEventsNamespace = "MyAutoTrack.Modules.Vehicles.IntegrationEvents";

    protected const string LifeCycleNamespace = "MyAutoTrack.Modules.LifeCycle";
    protected const string LifeCycleIntegrationEventsNamespace = "MyAutoTrack.Modules.LifeCycle.IntegrationEvents";

    protected const string MaintenanceNamespace = "MyAutoTrack.Modules.Maintenance";
    protected const string MaintenanceIntegrationEventsNamespace = "MyAutoTrack.Modules.Maintenance.IntegrationEvents";
}
