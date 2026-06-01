namespace Inventory.Management.Dtos;

public record CreateInventoryItemDto(
    string Name,
    string Type,
    int Quantity,
    decimal Price,
    DateOnly ExpirationDate,
    DateOnly LastOrdered
);