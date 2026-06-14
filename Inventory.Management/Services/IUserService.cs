using Inventory.Management.Dtos;
using Inventory.Management.Models;

namespace Inventory.Management.Services;

public interface IUserService
{
    Task<List<UserResponse>> GetAllUsersAsync();
    Task<UserResponse?> GetUserByIdAsync(int id);
    Task<UserResponse> AddUserAsync(CreateUserRequest user);
    // Task<bool> UpdateUserAsync(int id, UpdateUserRequest item);
    // Task<bool> DeleteUserAsync(int id);
}