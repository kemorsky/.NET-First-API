using Microsoft.AspNetCore.Mvc;
using Inventory.Management.Models;
using Microsoft.AspNetCore.Authorization;
using Inventory.Management.Services;
using Inventory.Management.Dtos;

namespace Inventory.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class UsersController(IUserService service) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
            => Ok(await service.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int Id)
        {
            var user = await service.GetUserByIdAsync(Id);

            if (user is null)
            {
                return NotFound("User with the given id was not found");
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserResponse>> AddUser(CreateUserRequest user)
        {
            var createdUser = await service.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id}, createdUser);
        }
            
    }
};