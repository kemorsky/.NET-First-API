namespace Inventory.Management.Dtos
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateOnly DateCreated { get; set; }
    }
};


public record InventoryDto(
    int Id,
    string Name,
    string Type,
    int Quantity,
    decimal Price,
    DateOnly ExpirationDate,
    DateOnly LastOrdered
);