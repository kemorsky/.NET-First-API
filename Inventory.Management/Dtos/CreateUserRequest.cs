using System.ComponentModel.DataAnnotations;

namespace Inventory.Management.Dtos;

public class CreateUserRequest
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateOnly SignUpDate { get; set; }
}