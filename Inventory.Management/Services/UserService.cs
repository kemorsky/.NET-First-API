using Inventory.Management.Data;
using Inventory.Management.Dtos;
using Inventory.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Management.Services;

public class UserService(AppDbContext context) : IUserService
{
    public async Task<List<UserResponse>> GetAllUsersAsync()
        => await context.Users.Select(c => new UserResponse
        {
            Id = c.Id,
            Username = c.Username,
            Email = c.Email,
            SignUpDate = c.SignUpDate,
        }).ToListAsync();

    public async Task<UserResponse?> GetUserByIdAsync(int id)
    {
        var result = await context.Users
            .Where(c => c.Id == id)
            .Select(c => new UserResponse
            {
                Id = c.Id,
                Username = c.Username,
                Email = c.Email,
                SignUpDate = c.SignUpDate
            })
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<UserResponse> AddUserAsync(CreateUserRequest user)
    {
        var newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
            SignUpDate = user.SignUpDate
        };
        
        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        return new UserResponse
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Email = newUser.Email,
            Password = newUser.Password,
            SignUpDate = newUser.SignUpDate
        };
    }
}