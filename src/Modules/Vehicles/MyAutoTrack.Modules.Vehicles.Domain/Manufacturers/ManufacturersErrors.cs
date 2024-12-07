using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

public static class ManufacturersErrors
{
    public static Error NotFound(Guid manufacturerId)
    {
        return Error.NotFound("Manufacturer.NotFound",
            $"The Manufacturer with the identifier {manufacturerId} was not found");
    }
    
    public static Error NotFound(string manufacturerId)
    {
        return Error.NotFound("Manufacturer.NotFound",
            $"The Manufacturer with the identifier {manufacturerId} was not found");
    }
}