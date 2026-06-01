namespace Inventory.Management.Dtos;

// A DTO is a contract, or a schema between the client and server that represents
// an agreement about what the transferred data will look like

public record InventoryDto(
    int Id,
    string Name,
    string Type,
    int Quantity,
    decimal Price,
    DateOnly ExpirationDate,
    DateOnly LastOrdered
);

