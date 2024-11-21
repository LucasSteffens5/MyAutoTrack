using System.Reflection;
using System.Reflection.Metadata;

namespace MyAutoTrack.Modules.Lifecycle.Presentation;

public static class PresentationLifeCycleAssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}