using Inventory.Management.Models;

namespace Inventory.Management.Services;

public class InventoryItemService : IInventoryItemService
{
    static List<InventoryItem> inventory = new List<InventoryItem> {
        new InventoryItem { Id = 1, Name = "Chicken Breast", Type = "Meat", Quantity = 3, Price = 59.95M, ExpirationDate = new DateOnly(2026, 6, 02), LastOrdered = new DateOnly(2026, 5, 29) },
        new InventoryItem { Id = 2, Name = "Apple", Type = "Fruit", Quantity = 7, Price = 20.75M, ExpirationDate = new DateOnly(2026, 6, 05), LastOrdered = new DateOnly(2026, 5, 27) },
        new InventoryItem { Id = 3, Name = "Milk", Type = "Dairy", Quantity = 1, Price = 17.85M, ExpirationDate = new DateOnly(2026, 6, 01), LastOrdered = new DateOnly(2026, 5, 27) },
        new InventoryItem { Id = 4, Name = "Potatoes", Type = "Vegetable", Quantity = 2, Price = 13.85M, ExpirationDate = new DateOnly(2026, 6, 03), LastOrdered = new DateOnly(2026, 5, 27) },
    };

    public async Task<List<InventoryItem>> GetAllInventoryItemsAsync()
    => await Task.FromResult(inventory);

    public async Task<InventoryItem?> GetItemById(int id)
    {
        var result = inventory.FirstOrDefault(i => i.Id == id);
       
        return await Task.FromResult(result);
    }

    public Task<InventoryItem> AddItemAsync(InventoryItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateItemAsync(int id, InventoryItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteItemAsync(int id)
    {
        throw new NotImplementedException();
    }
}