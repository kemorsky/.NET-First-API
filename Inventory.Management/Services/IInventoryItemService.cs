using Inventory.Management.Dtos;
using Inventory.Management.Models;

namespace Inventory.Management.Services;

public interface IInventoryItemService
{
    Task<List<InventoryItemResponse>> GetAllInventoryItemsAsync();
    Task<InventoryItemResponse?> GetItemById(int id);
    Task<InventoryItemResponse> AddItemAsync(InventoryItem item);
    Task<bool> UpdateItemAsync(int id, InventoryItem item);
    Task<bool> DeleteItemAsync(int id);
};