using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

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
    
    public ICollection<MaintenanceItem> MaintenanceItems { get; set; }

    public static Item Create(string requestName, string requestType, decimal requestPrice, long requestInventory)
    {
        var item = new Item
        {
            Name = requestName,
            Type = requestType,
            Price = requestPrice,
            Inventory = requestInventory
        };
        
        return item;
    }
}