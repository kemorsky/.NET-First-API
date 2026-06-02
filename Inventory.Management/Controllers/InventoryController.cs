using Microsoft.AspNetCore.Mvc;
using Inventory.Management.Models;
using Microsoft.AspNetCore.Authorization;
using Inventory.Management.Services;

namespace Inventory.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]

    public class InventoryController(IInventoryItemService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<InventoryItem>>> GetInventoryItem() 
            => Ok(await service.GetAllInventoryItemsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInventoryItem(int id)
        {
            var item = await service.GetItemById(id);
            
            if (item is null)
            {
                return NotFound("Item with the given Id was not found.");
            }

            return Ok(item);
        }
            
    }
};