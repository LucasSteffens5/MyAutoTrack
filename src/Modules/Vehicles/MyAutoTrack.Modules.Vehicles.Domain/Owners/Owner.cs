namespace MyAutoTrack.Modules.Vehicles.Domain.Owners;

public class Owner
{
    private Owner()
    {
        
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }
}