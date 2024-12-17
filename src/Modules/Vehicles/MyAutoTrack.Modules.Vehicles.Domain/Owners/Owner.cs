using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Vehicles.Domain.Owners;

public class Owner
{
    private Owner()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public static Owner Create(string name, Guid ownerId)
    {
        var owner = new Owner
        {
            Name = name,
            Id = ownerId
        };

        return owner;
    }
}