using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Inventory.Management.Dtos;
using Inventory.Management.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Inventory.Management.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]

    public class AuthController(IAuthService service) : ControllerBase
    {

        [HttpPost("signin")]
        public async Task<ActionResult<UserResponse>> SignIn([FromBody] SignInRequest request)
        {
            var user = await service.ValidateCredentialsAsync(request.Email, request.Password);

            if (user is null)
            {
                return Unauthorized("Invalid email or password");
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Issue a cookie to frontend
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = true // Keeps user logged in even if they close the browser
                });
            
            return Ok(user);
        }

        [HttpPost("signout")]
        public async Task<IActionResult> Logout()
        {
            // Clear the cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Logged out successfully" });
        }
    }
}