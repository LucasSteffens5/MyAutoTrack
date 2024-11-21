
using System.Reflection;
using MyAutoTrack.ArchitectureTests.Abstractions;
using MyAutoTrack.Modules.Lifecycle.Domain;
using MyAutoTrack.Modules.Lifecycle.Infrastructure;
using MyAutoTrack.Modules.Lifecycle.Presentation;

using MyAutoTrack.Modules.Maintenance.Domain;
using MyAutoTrack.Modules.Maintenance.Infrastructure;
using MyAutoTrack.Modules.Maintenance.Presentation;
using MyAutoTrack.Modules.Users.Domain;
using MyAutoTrack.Modules.Users.Infrastructure;
using MyAutoTrack.Modules.Users.Presentation;
using MyAutoTrack.Modules.Vehicles.Domain;
using MyAutoTrack.Modules.Vehicles.Infrastructure;
using MyAutoTrack.Modules.Vehicles.Presentation;
using NetArchTest.Rules;

namespace MyAutoTrack.ArchitectureTests.Layers;

public class ModuleTests : BaseTest
{
    [Fact]
    public void UsersModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [VehiclesNamespace, LifeCycleNamespace, MaintenanceNamespace];
        string[] integrationEventsModules =
        [
            VehiclesIntegrationEventsNamespace,
            LifeCycleIntegrationEventsNamespace,
            MaintenanceIntegrationEventsNamespace
        ];

        List<Assembly> usersAssemblies =
        [
            typeof(DomainUsersAssemblyReference).Assembly,
            Modules.Users.Application.AssemblyReference.Assembly,
            PresentationUsersAssemblyReference.Assembly,
            typeof(UsersModule).Assembly
        ];

        Types.InAssemblies(usersAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void LifeCycleModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, LifeCycleNamespace, MaintenanceNamespace];
        string[] integrationEventsModules =
        [
            UsersIntegrationEventsNamespace,
            LifeCycleIntegrationEventsNamespace,
            MaintenanceIntegrationEventsNamespace
        ];

        List<Assembly> lifeCycleAssemblies =
        [
            typeof(DomainLifeCycleAssemblyReference).Assembly,
            Modules.Lifecycle.Application.AssemblyReference.Assembly,
            PresentationLifeCycleAssemblyReference.Assembly,
            typeof(LifeCycleModule).Assembly
        ];

        Types.InAssemblies(lifeCycleAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void MaintenanceModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, VehiclesNamespace, LifeCycleIntegrationEventsNamespace];
        string[] integrationEventsModules =
        [
            UsersIntegrationEventsNamespace,
            VehiclesIntegrationEventsNamespace,
            MaintenanceIntegrationEventsNamespace
        ];

        List<Assembly> maintenanceAssemblies =
        [
            typeof(DomainMaintenanceAssemblyReference).Assembly,
            Modules.Maintenance.Application.AssemblyReference.Assembly,
            PresentationMaintenanceAssemblyReference.Assembly,
            typeof(MaintenanceModule).Assembly
        ];

        Types.InAssemblies(maintenanceAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void Vehicles_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, MaintenanceIntegrationEventsNamespace, LifeCycleNamespace];
        string[] integrationEventsModules =
        [
            UsersIntegrationEventsNamespace,
            VehiclesIntegrationEventsNamespace,
            LifeCycleIntegrationEventsNamespace
        ];

        List<Assembly> vehiclesAssemblies =
        [
            typeof(DomainVehiclesAssemblyReference).Assembly,
            Modules.Vehicles.Application.AssemblyReference.Assembly,
            PresentationVehiclesAssemblyReference.Assembly,
            typeof(VehiclesModule).Assembly
        ];

        Types.InAssemblies(vehiclesAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
