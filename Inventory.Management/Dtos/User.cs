namespace Inventory.Management.Dtos
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateOnly DateCreated { get; set; }
    }
};