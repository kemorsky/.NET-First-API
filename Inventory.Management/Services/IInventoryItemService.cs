using Inventory.Management.Models;

namespace Inventory.Management.Services;

public interface IInventoryItemService
{
    Task<List<InventoryItem>> GetAllInventoryItemsAsync();
    Task<InventoryItem?> GetItemById(int id);
    Task<InventoryItem> AddItemAsync(InventoryItem item);
    Task<bool> UpdateItemAsync(int id, InventoryItem item);
    Task<bool> DeleteItemAsync(int id);
};