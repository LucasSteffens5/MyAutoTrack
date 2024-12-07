using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

public static class VehiclesErrors
{
    public static Error NotFound(Guid Id)
    {
        return Error.NotFound("Vehicles.NotFound", $"The Vehicle with the identifier {Id} not found");
    }

    public static Error NotFound(string Id)
    {
        return Error.NotFound("Vehicles.NotFound", $"The Vehicle with the identifier {Id} not found");
    }
}