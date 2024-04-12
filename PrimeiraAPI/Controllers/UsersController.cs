using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result);
        }
    }
}
