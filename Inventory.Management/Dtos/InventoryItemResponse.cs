using System.ComponentModel.DataAnnotations;

namespace Inventory.Management.Dtos;

// A DTO is a contract, or a schema between the client and server that represents
// an agreement about what the transferred data will look like

public class InventoryItemResponse
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

// public record InventoryDto(
//     int Id,
//     string Name,
//     string Type,
//     int Quantity,
//     decimal Price,
//     DateOnly ExpirationDate,
//     DateOnly LastOrdered
// );

