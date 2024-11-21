using System.Reflection;
using System.Reflection.Metadata;
using MyAutoTrack.Modules.Lifecycle.Domain;
using MyAutoTrack.Modules.Lifecycle.Infrastructure;
using MyAutoTrack.Modules.Lifecycle.Presentation;

namespace MyAutoTrack.Modules.Lifecycle.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(DomainLifeCycleAssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(LifeCycleModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(PresentationLifeCycleAssemblyReference).Assembly;
}