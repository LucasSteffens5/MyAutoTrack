using System.Reflection;

namespace MyAutoTrack.Modules.Maintenance.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}