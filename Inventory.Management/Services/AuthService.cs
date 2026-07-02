using Inventory.Management.Data;
using Inventory.Management.Dtos;
using Inventory.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Management.Services;

public class AuthService(AppDbContext context) : IAuthService
{
    public async Task<UserResponse?> ValidateCredentialsAsync(string email, string password)
    {
        var result = await context.Users
            .Where(c => c.Email == email && c.Password == password)
            .Select(c=> new UserResponse
            {
                Email = c.Email,
                Password = c.Password
            })
            .FirstOrDefaultAsync();

            return result;
    }
}