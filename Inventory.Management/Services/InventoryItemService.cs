using Inventory.Management.Data;
using Inventory.Management.Dtos;
using Inventory.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Management.Services;

public class InventoryItemService(AppDbContext context) : IInventoryItemService
{
    // static List<InventoryItem> inventory = new List<InventoryItem> {
    //     new InventoryItem { Id = 1, Name = "Chicken Breast", Type = "Meat", Quantity = 3, Price = 59.95M, ExpirationDate = new DateOnly(2026, 6, 02), LastOrdered = new DateOnly(2026, 5, 29) },
    //     new InventoryItem { Id = 2, Name = "Apple", Type = "Fruit", Quantity = 7, Price = 20.75M, ExpirationDate = new DateOnly(2026, 6, 05), LastOrdered = new DateOnly(2026, 5, 27) },
    //     new InventoryItem { Id = 3, Name = "Milk", Type = "Dairy", Quantity = 1, Price = 17.85M, ExpirationDate = new DateOnly(2026, 6, 01), LastOrdered = new DateOnly(2026, 5, 27) },
    //     new InventoryItem { Id = 4, Name = "Potatoes", Type = "Vegetable", Quantity = 2, Price = 13.85M, ExpirationDate = new DateOnly(2026, 6, 03), LastOrdered = new DateOnly(2026, 5, 27) },
    // };

    public async Task<List<InventoryItemResponse>> GetAllInventoryItemsAsync()
        => await context.Items.Select(c => new InventoryItemResponse
        {
            Id = c.Id,
            Name = c.Name,
            Type = c.Type,
            Quantity = c.Quantity,
            Price = c.Price,
            ExpirationDate = c.ExpirationDate,
            LastOrdered = c.LastOrdered
        }).ToListAsync();

    public async Task<InventoryItemResponse?> GetItemById(int id)
    {
        var result = await context.Items
            .Where(c => c.Id == id)
            .Select(c => new InventoryItemResponse
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                Quantity = c.Quantity,
                Price = c.Price,
                ExpirationDate = c.ExpirationDate,
                LastOrdered = c.LastOrdered
            })
            .FirstOrDefaultAsync();
       
        return result;
    }


    public async Task<InventoryItemResponse> AddItemAsync(CreateInventoryItemRequest item)
    {
        var newItem = new InventoryItem
        {
            Name = item.Name,
            Type = item.Type,
            Quantity = item.Quantity,
            Price = item.Price,
            ExpirationDate = item.ExpirationDate,
            LastOrdered = item.LastOrdered
        };
        
        context.Items.Add(newItem);
        await context.SaveChangesAsync();

        return new InventoryItemResponse
        {
            Id = newItem.Id,
            Name = newItem.Name,
            Type = newItem.Type,
            Quantity = newItem.Quantity,
            Price = newItem.Price,
            ExpirationDate = newItem.ExpirationDate,
            LastOrdered = newItem.LastOrdered
        };
    }

    public async Task<bool> UpdateItemAsync(int id, UpdateInventoryItemRequest item)
    {
        var existingItem = await context.Items.FindAsync(id);

        if (existingItem is null) return false;

        existingItem.Name = item.Name;
        existingItem.Type = item.Type;
        existingItem.Quantity = item.Quantity;
        existingItem.Price = item.Price;
        existingItem.ExpirationDate = item.ExpirationDate;
        existingItem.LastOrdered = item.LastOrdered;

        await context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var itemToDelete = await context.Items.FindAsync(id);

        if (itemToDelete is null) return false;

        context.Items.Remove(itemToDelete);
        await context.SaveChangesAsync();
        
        return true;
    }
}