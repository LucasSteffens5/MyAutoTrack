using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenance;

public sealed class Item : Entity
{
    private Item()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public long Inventory { get; set; }
}