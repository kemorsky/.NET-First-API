using Microsoft.AspNetCore.Mvc;
using Inventory.Management.Models;
using Microsoft.AspNetCore.Authorization;
using Inventory.Management.Services;
using Inventory.Management.Dtos;

namespace Inventory.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]

    public class InventoryController(IInventoryItemService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<InventoryItemResponse>>> GetInventoryItem() 
            => Ok(await service.GetAllInventoryItemsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemResponse>> GetInventoryItem(int id)
        {
            var item = await service.GetItemById(id);
            
            if (item is null)
            {
                return NotFound("Item with the given Id was not found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryItemResponse>> AddInventoryItem(CreateInventoryItemRequest item)
        {
            var createdItem = await service.AddItemAsync(item);
            return CreatedAtAction(nameof(GetInventoryItem), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInventoryItem(int id, UpdateInventoryItemRequest item)
        {
            var updatedItem = await service.UpdateItemAsync(id, item);
            return updatedItem ? NoContent() : NotFound("Item with the given id was not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventoryItem(int id)
        {
            var deletedItem = await service.DeleteItemAsync(id);
            return deletedItem ? NoContent() : NotFound("Item with the given id was not found");
        }
    }
};