using System.Reflection;
using System.Reflection.Metadata;
using MyAutoTrack.Modules.Users.Domain;
using MyAutoTrack.Modules.Users.Infrastructure;
using Presentation;

namespace MyAutoTrack.Modules.Users.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(DomainUsersAssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(UsersModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(PresentationUsersAssemblyReference).Assembly;
}