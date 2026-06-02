using System.ComponentModel.DataAnnotations;

namespace Inventory.Management.Models
{
    public class InventoryItem
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Product name must be specified")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product type must be specified")]
        public string Type { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateOnly ExpirationDate { get; set; }
        
        public DateOnly LastOrdered { get; set; }
    }
};