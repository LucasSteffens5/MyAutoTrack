using System.Reflection;
using System.Reflection.Metadata;
using MyAutoTrack.Modules.Vehicles.Domain;
using MyAutoTrack.Modules.Vehicles.Infrastructure;
using MyAutoTrack.Modules.Vehicles.Presentation;

namespace MyAutoTrack.Modules.Vehicles.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(DomainVehiclesAssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(VehiclesModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(PresentationVehiclesAssemblyReference).Assembly;
}