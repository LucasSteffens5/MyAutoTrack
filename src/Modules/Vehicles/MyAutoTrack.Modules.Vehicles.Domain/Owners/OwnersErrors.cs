using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Owners;

public static class OwnersErrors
{
    public static Error NotFound(Guid ownerId)
    {
        return Error.NotFound("Owners.NotFound",
            $"The owner with the identifier {ownerId} was not found");
    }
    
    public static Error NotFound(string ownerId)
    {
        return Error.NotFound("Owners.NotFound",
            $"The owner with the identifier {ownerId} was not found");
    }
   
}