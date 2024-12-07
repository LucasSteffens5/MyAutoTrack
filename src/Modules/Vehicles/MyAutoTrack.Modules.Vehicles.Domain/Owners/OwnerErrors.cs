using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Owners;

public static class OwnerErrors
{
    
    public static Error NotFound(Guid ownerId)
    {
        return Error.NotFound("Owner.NotFound", $"The Owner with the identifier {ownerId} was not found");
    }
}
