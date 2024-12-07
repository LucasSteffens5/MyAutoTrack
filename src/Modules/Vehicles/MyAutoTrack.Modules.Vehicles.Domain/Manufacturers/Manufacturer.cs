namespace MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

public sealed class Manufacturer
{
    private Manufacturer()
    {
        
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }
    
    
    public static Manufacturer Create(string name)
    {
        var manufacturer = new Manufacturer
        {
            Name = name,
            Id = Guid.NewGuid()
        };

        return manufacturer;
    }
}