namespace Inventory.Management.Dtos;

public class UpdateInventoryItemRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateOnly ExpirationDate { get; set; }
    
    public DateOnly LastOrdered { get; set; }
}