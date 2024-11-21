using System.Reflection;
using System.Reflection.Metadata;
using MyAutoTrack.Modules.Maintenance.Domain;
using MyAutoTrack.Modules.Maintenance.Infrastructure;
using MyAutoTrack.Modules.Maintenance.Presentation;

namespace MyAutoTrack.Modules.Maintenance.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(DomainMaintenanceAssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(MaintenanceModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(PresentationMaintenanceAssemblyReference).Assembly;
}