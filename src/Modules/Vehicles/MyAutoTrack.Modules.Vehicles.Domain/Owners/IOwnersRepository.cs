namespace MyAutoTrack.Modules.Vehicles.Domain.Owners;

public interface IOwnersRepository
{
    Task<Owner?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Owner owner);

    public void Update(Owner owner);
}