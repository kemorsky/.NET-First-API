using Inventory.Management.Dtos;
using Inventory.Management.Models;

namespace Inventory.Management.Services;

public interface IAuthService
{
    Task<UserResponse?> ValidateCredentialsAsync(string email, string password); 
}