namespace MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

public sealed class Manufacturer
{
    private Manufacturer()
    {
        
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }
}