using System.Reflection;

namespace MyAutoTrack.Modules.Lifecycle.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}